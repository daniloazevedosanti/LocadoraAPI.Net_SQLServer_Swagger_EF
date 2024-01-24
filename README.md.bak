## 🖥 Instruções 

- abra a visual studio e depois abra o projeto (adicione o projeto Test caso não abra completamente) 
- no menu no visual studio: Tools (Ferramentas) > Nuget Package Manager > Package Manager Console
	- digite no console `dotnet restore` (restaura todas as dependencias do projeto)
	- Configure a instancia do seu banco de dados  no appsettings.json, está com o banco de nome 'Locadora'
	- Para ficar fácil testar, crie um banco com esse nome Locadora no seu SQL Server.
	- Em seguida restaure as configurações de tabelas e objetos no banco
- No Package Manager Console digite `dotnet ef database update` esse comando ira criar 
- a estrutura banco de dados do projeto
- `dotnet run` ou executar o projeto no visual studio
- Coloquei um swagger para facilitar e os tem a documentação de como usar a api com os bodys de request
- Segue também nesse projeto uma collection para usar no postman e alguns prints de exemplo de funcionamento.

### 💻 Exemplos

### 💻 Autenticação

- Primeiro crie um usuario, depois de feito isso, irá conseguir usar as outras rotas via token.
- Acesse via POST a seguinte URL: `https://localhost:44354/Autenticacao` passando no corpo da requisição as seguintes informações:

```
  {
    "Nome": "Nome do Usuario",
    "Email": "emailDoUsuario@email.com",
    "Senha": "admin@123"
  }
  ```
  
- Vai devolver algo do tipo:
 
 ```
 {
    "auth": true,
    "usuario": {
        "id": 4,
        "nome": "Nome do Usuario",
        "email": "emailDoUsuario@email.com",
        "senha": ""
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Impvbmhqb25oQGFkbWluLmNvbSIsIm5iZiI6MTcwNjEyMTIyMCwiZXhwIjoxNzA2MTI4NDIwLCJpYXQiOjE3MDYxMjEyMjB9.NjwFRidi0WG8hIMNBcG-14yb9ShSm3pjRN3Jnhj9kWY"
}
```

 Token ("token") é utilizado para conseguir fazer as solicitações onde necessite autorização.
 
 Siga o pdf de exemplos para os demais endpoints.
 