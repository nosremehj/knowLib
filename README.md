# Projeto KnowLib

KnowLib é uma aplicação web desenvolvida para gerenciar e exibir artigos e eBooks. Esta aplicação permite que usuários visualizem os artigos e eBooks disponíveis, com funcionalidades de CRUD para cada item, e exibição organizada em formato de cards, o que facilita a navegação e a leitura dos resumos. O projeto foi construído com ASP.NET MVC e utiliza o Entity Framework para gerenciar o banco de dados.

# Funcionalidades

- Exibição de Artigos e eBooks: Lista de artigos e eBooks com exibição em cards responsivos.
- CRUD Completo para Artigos e eBooks:
  - Criar novos artigos e eBooks.
  - Ler informações detalhadas de cada item.
  - Editar informações de artigos e eBooks.
  - Excluir artigos e eBooks.
- Listagem Responsiva: Exibição em cards, com organização lado a lado em telas maiores, adaptando-se bem em dispositivos móveis.
- Truncamento de Resumos com Tooltip: Exibição de resumos com texto truncado e tooltip para melhor visualização.
- Login por e-mail e confirmação de e-mail.

# Tecnologias Utilizadas

- ASP.NET MVC: Framework utilizado para a construção da aplicação web.
- Entity Framework: ORM para manipulação e mapeamento dos dados no banco de dados.
- Bootstrap: Biblioteca CSS para responsividade e estilização.
- SQL Server: Banco de dados utilizado para armazenar artigos e eBooks.

# Pré-requisitos

- .NET Framework: versão 4.7.2 ou superior.
- SQL Server: Configuração do banco de dados para armazenar informações de artigos e eBooks.
- IDE: Visual Studio ou Visual Studio Code para desenvolvimento e execução do projeto.

## Configuração e Execução

- Clone o Repositório
  - Clone o repositório do projeto para a sua máquina local:

```http
  https://github.com/nosremehj/knowLib.git
```

- Configurar o Banco de Dados
  - No arquivo Web.config, configure a string de conexão para o banco de dados SQL Server que será utilizado:
  - Obs: Necessário o uso do SQL atualizado para a ultima versão. Manter Criptografia como Opcional e marcar o Certificado do Servidor Confiável.

```conexao
   <connectionStrings>
   <add name="AppDbContext" connectionString="Data Source=Nome do Servidor;Initial Catalog=knowLib;Integrated Security=True;TrustServerCertificate=True; Encrypt=False;" providerName="System.Data.SqlClient" />
 </connectionStrings>
```

- Aplicar Migrations e Configurar o Banco

  - Com o Entity Framework, aplique as migrations para criar as tabelas no banco de dados:

  ```migrations
  Update-Database
  ```

- Após isso, acesse o projeto, rode e ele irá abrir uma aba no navegador. Caso, não abra, acesse essa possível porta/rota:

```
https://localhost:44339/Account/Login
```

# Sistema de Login

- Com o uso do mailtrap para fazer receber a confirmação de e-mail e por motivos de ser pago para redirecionar para o e-mails (google, hotmail e etc), irei disponibilizar credências para fazer o uso desse modelo de confirmação de e-mail.
  Faça o acesso nesse link: https://mailtrap.io/signin

```Credenciais
E-mail:tp3jhemerson1@gmail.com
Senha:NK*tp32024
```

Após o login efetuado, vá para: https://mailtrap.io/inboxes e clique em "**My inbox**".
Volte para a aplicação e faça o cadastro. Aguarde o e-mail ser recebido na caixa de inbox.
Você irá receber algo desse tipo:

```Link
Clique no link para confirmar sua conta: "http://localhost:5000/Account/ConfirmEmail?token=7J%2BlyKrhDaWKULUvrBrfzKykIHHtXvb5kzQiv%2BH0prs1OyXY%2Bk08sYN27EasJQU2aLk%3D"
```

Pegue essa parte da mensagem:

```
http://localhost:5000/Account/ConfirmEmail?token=7J%2BlyKrhDaWKULUvrBrfzKykIHHtXvb5kzQiv%2BH0prs1OyXY%2Bk08sYN27EasJQU2aLk%3D
```

E cole em uma nova aba do seu navegador. Após isso o processo de confirmação de e-mail estará concluído e você poderá efetuar o login e usar o Sistema.

## Em caso de duvidas mande um e-mail para:

tijhemerson@gmail.com

# Licença

Este projeto está sob a licença MIT. Consulte o arquivo LICENSE para obter mais informações.
