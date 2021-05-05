# PoliceDepartment API

API referente ao teste da **Cidade Alta Season 2**.

## Desenvolvimento

O projeto foi desenvolvido em .Net Core 3.1 com arquitetura em camadas, constando as seguintes camadas:

|Camada		| Fun��o|
|Service/Api| Camada de API com toda a interface entre o consumidor e as funcionalidades|
|Domain		| Camada de dom�nio com toda a regra de neg�cio da aplica��o|
|Auth		| Camada com todas as regras de autentica��o|
|Data		| Camada com toda parte de acesso � dados|
|IoC		| Camada Inversion Of Control (IoC) para fazer todo o bootstraping da aplica��o|

As seguintes bibliotecas/conceitos foram utilizados:

- FluentValidator
- EntityFrameworkCore
- OData
- Swagger
- Serilog
- Versionamento de API
- Criptografia de senha de usu�rio (N�o sendo humanamente leg�vel consultando diretamente no banco)

## Considera��es

Banco utilizado foi o Postgresql, portanto nomes de colunas e tabelas atenderam aos padr�es do Postgres, utilizando underscore (`_`) no lugar de camelcase e tudo em min�sculo, 
no entanto, as entidades no C# sempre obedecendo ao padr�o do C#.

A biblioteca OData foi utilizada para fazer toda a parte de filtros e ordena��es que eram requisitos para a aplica��o. Por favor, consulte a documenta��o para saber como usar: https://www.odata.org/odata-services/


> Se necess�rio, os scripts SQL est�o na pasta `sql` do reposit�rio.