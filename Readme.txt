Requisitos para executar o serviço da API e os testes

Softwares:
Visual Studio 2019 Community
Sql Server 2019 Express

criar o Banco de Dados: AFJ
executar o script do banco que está no Git

Compilar o Projeto no visual studio

Tests da API : PostMan

exemplo: Usando tipo JSON

GET
[
  {
    "PlanoTipo": "Controle",
    "Operadora":"",
    "Codigo": "",
    "DDD": 0
  }
]

POST
[
  {
    "Codigo": "44551",
    "Minutos": 5,
    "FranquiaInternet": "plano novo codigo4",
    "Valor": 16.0,
    "IdPlanoTipo": 2
  },
  {
    "Codigo": "22331",
    "Minutos": 60,
    "FranquiaInternet": "franquia codigo novo 7",
    "Valor": 7.0,
    "IdPlanoTipo": 3
  }
]