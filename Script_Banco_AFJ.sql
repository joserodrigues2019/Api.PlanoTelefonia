USE [AFJ]
GO
/****** Object:  Table [dbo].[PLANO_TELEFONIA]    Script Date: 15/10/2020 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLANO_TELEFONIA](
	[PLANO_ID] [int] IDENTITY(1,1) NOT NULL,
	[PLANO_CODIGO] [varchar](10) NOT NULL,
	[PLANO_MINUTOS] [int] NULL,
	[PLANO_FRANQUIA_INTERNET] [varchar](50) NULL,
	[PLANO_VALOR] [decimal](18, 0) NULL,
	[PLANO_ID_TIPO] [int] NOT NULL,
	[PLANO_DATA_CADASTRO] [datetime] NOT NULL,
	[PLANO_DDD] [int] NOT NULL,
	[PLANO_OPERADORA] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PLANO_TELEFONIA] PRIMARY KEY CLUSTERED 
(
	[PLANO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLANO_TIPO]    Script Date: 15/10/2020 12:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLANO_TIPO](
	[PLANO_ID_TIPO] [int] IDENTITY(1,1) NOT NULL,
	[PLANO_DESCRICAO_TIPO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PLANO_TIPO] PRIMARY KEY CLUSTERED 
(
	[PLANO_ID_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PLANO_TELEFONIA] ON 
GO
INSERT [dbo].[PLANO_TELEFONIA] ([PLANO_ID], [PLANO_CODIGO], [PLANO_MINUTOS], [PLANO_FRANQUIA_INTERNET], [PLANO_VALOR], [PLANO_ID_TIPO], [PLANO_DATA_CADASTRO], [PLANO_DDD], [PLANO_OPERADORA]) VALUES (1, N'12345', 1, N'teste franquia metodo listar Ok 1', CAST(10 AS Decimal(18, 0)), 1, CAST(N'2020-10-13T00:00:00.000' AS DateTime), 92, N'TIM')
GO
INSERT [dbo].[PLANO_TELEFONIA] ([PLANO_ID], [PLANO_CODIGO], [PLANO_MINUTOS], [PLANO_FRANQUIA_INTERNET], [PLANO_VALOR], [PLANO_ID_TIPO], [PLANO_DATA_CADASTRO], [PLANO_DDD], [PLANO_OPERADORA]) VALUES (4, N'44551', 5, N'plano novo teste de alteração!!!', CAST(16 AS Decimal(18, 0)), 2, CAST(N'2020-10-13T20:51:58.880' AS DateTime), 91, N'CLARO')
GO
INSERT [dbo].[PLANO_TELEFONIA] ([PLANO_ID], [PLANO_CODIGO], [PLANO_MINUTOS], [PLANO_FRANQUIA_INTERNET], [PLANO_VALOR], [PLANO_ID_TIPO], [PLANO_DATA_CADASTRO], [PLANO_DDD], [PLANO_OPERADORA]) VALUES (5, N'22331', 60, N'franquia codigo novo 7', CAST(7 AS Decimal(18, 0)), 3, CAST(N'2020-10-13T20:51:58.883' AS DateTime), 11, N'VIVO')
GO
SET IDENTITY_INSERT [dbo].[PLANO_TELEFONIA] OFF
GO
SET IDENTITY_INSERT [dbo].[PLANO_TIPO] ON 
GO
INSERT [dbo].[PLANO_TIPO] ([PLANO_ID_TIPO], [PLANO_DESCRICAO_TIPO]) VALUES (1, N'Controle')
GO
INSERT [dbo].[PLANO_TIPO] ([PLANO_ID_TIPO], [PLANO_DESCRICAO_TIPO]) VALUES (2, N'Pós')
GO
INSERT [dbo].[PLANO_TIPO] ([PLANO_ID_TIPO], [PLANO_DESCRICAO_TIPO]) VALUES (3, N'Pré')
GO
SET IDENTITY_INSERT [dbo].[PLANO_TIPO] OFF
GO
ALTER TABLE [dbo].[PLANO_TELEFONIA] ADD  CONSTRAINT [DF_PLANO_TELEFONIA_PLANO_DATA_CADASTRO]  DEFAULT (getdate()) FOR [PLANO_DATA_CADASTRO]
GO
ALTER TABLE [dbo].[PLANO_TELEFONIA]  WITH CHECK ADD  CONSTRAINT [FK_PLANO_TELEFONIA_PLANO_TIPO] FOREIGN KEY([PLANO_ID_TIPO])
REFERENCES [dbo].[PLANO_TIPO] ([PLANO_ID_TIPO])
GO
ALTER TABLE [dbo].[PLANO_TELEFONIA] CHECK CONSTRAINT [FK_PLANO_TELEFONIA_PLANO_TIPO]
GO
