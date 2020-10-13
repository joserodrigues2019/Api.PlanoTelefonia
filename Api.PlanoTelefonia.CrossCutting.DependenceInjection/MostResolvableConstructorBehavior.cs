using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Api.PlanoTelefonia.CrossCutting.DependenceInjection
{
	/// <summary>
	/// Resolução do problema do SimpleInjector para multíplos contrutores padrões (Dependency Injection anti-pattern: multiple constructors)
	/// https://vladimirhil.com/2016/06/24/sitecore-and-simpleinjector-issues-with-wffm/
	/// https://simpleinjector.readthedocs.io/en/latest/extensibility.html#overriding-constructor-resolution-behavior
	/// </summary>
	public class MostResolvableConstructorBehavior : IConstructorResolutionBehavior
	{
		private readonly Container container;

		public MostResolvableConstructorBehavior(Container container)
		{
			this.container = container;
		}

		private bool IsCalledDuringRegistrationPhase => !this.container.IsLocked();

		[DebuggerStepThrough]
		public ConstructorInfo GetConstructor(Type implementationType)
		{
			var constructor = this.GetConstructors(implementationType).FirstOrDefault();
			if (constructor != null) return constructor;
			throw new ActivationException(BuildExceptionMessage(implementationType));
		}

		private IEnumerable<ConstructorInfo> GetConstructors(Type implementation) =>
			from ctor in implementation.GetConstructors()
			let parameters = ctor.GetParameters()
			where this.IsCalledDuringRegistrationPhase
				|| implementation.GetConstructors().Length == 1
				|| ctor.GetParameters().All(this.CanBeResolved)
			orderby parameters.Length descending
			select ctor;

		private bool CanBeResolved(ParameterInfo parameter) =>
			this.GetInstanceProducerFor(new InjectionConsumerInfo(parameter)) != null;

		private InstanceProducer GetInstanceProducerFor(InjectionConsumerInfo i) =>
			this.container.Options.DependencyInjectionBehavior.GetInstanceProducer(i, false);

		private static string BuildExceptionMessage(Type type) =>
			!type.GetConstructors().Any()
				? TypeShouldHaveAtLeastOnePublicConstructor(type)
				: TypeShouldHaveConstructorWithResolvableTypes(type);

		private static string TypeShouldHaveAtLeastOnePublicConstructor(Type type) =>
			string.Format(CultureInfo.InvariantCulture,
				"For the container to be able to create {0}, it should contain at least " +
				"one public constructor.", type.ToFriendlyName());

		private static string TypeShouldHaveConstructorWithResolvableTypes(Type type) =>
			string.Format(CultureInfo.InvariantCulture,
				"For the container to be able to create {0}, it should contain a public " +
				"constructor that only contains parameters that can be resolved.",
				type.ToFriendlyName());
	}
}
