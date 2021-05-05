# PoliceDepartment API

API referente ao teste da **Cidade Alta Season 2**.

## Desenvolvimento

O projeto foi desenvolvido em .Net Core 3.1 com arquitetura em camadas, constando as seguintes camadas:

|Camada		| Função|
|Service/Api| Camada de API com toda a interface entre o consumidor e as funcionalidades|
|Domain		| Camada de domínio com toda a regra de negócio da aplicação|
|Auth		| Camada com todas as regras de autenticação|
|Data		| Camada com toda parte de acesso à dados|
|IoC		| Camada Inversion Of Control (IoC) para fazer todo o bootstraping da aplicação|

As seguintes bibliotecas/conceitos foram utilizados:

- FluentValidator
- EntityFrameworkCore
- OData
- Swagger
- Serilog
- Versionamento de API
- Criptografia de senha de usuário (Não sendo humanamente legível consultando diretamente no banco)

## Considerações

Banco utilizado foi o Postgresql, portanto nomes de colunas e tabelas atenderam aos padrões do Postgres, utilizando underscore (`_`) no lugar de camelcase e tudo em minúsculo, 
no entanto, as entidades no C# sempre obedecendo ao padrão do C#.

A biblioteca OData foi utilizada para fazer toda a parte de filtros e ordenações que eram requisitos para a aplicação. Por favor, consulte a documentação para saber como usar: https://www.odata.org/odata-services/


> Se necessário, os scripts SQL estão na pasta `sql` do repositório.