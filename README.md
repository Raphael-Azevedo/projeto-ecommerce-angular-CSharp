# API .NET
Neste repositório encontra-se a criação de uma api feita na ultima semana de estudos de api.

Foram realizados todas as cerimonias do scrum nesse projeto, desde a planning para levantar o que seria feito e como seria feito, as dailys todos os dias para comentar sobre as dificuldades e o andamento do projeto e no ultimo dia foi feito o code review e levantado o que poderia ser melhorado e quais foram as lições aprendidas.

Lista de tarefas desempenhadas.
<p align="center">
    <img width = "470" src="/img/Task.PNG">
</p>

Link do notion onde foi documentado as reuniões e informações sobre o projeto: https://humorous-profit-623.notion.site/API-f442fdde68bf41b1b249bef8a5977322

Criado o back end utilizando c# com o framework .NET 5;

Criado Front end que consumirá a api do back end em angular 13;

****
## Funcionalidades

Site de ecommerce com as seguintes funcionalidades:
- Listar, adicionar, remover e alterar Produtos;
- Listar, adicionar, remover e alterar Comentários;
- Listar, adicionar, remover e alterar Avaliação;
- Listar, adicionar, remover e alterar Estoque;
- Cadastro e Login de usuarios;
- Envio de Email para confirmar o usuario;
- Envio de Email para resetar a senha;

****
## Tecnologias utilizadas
- `Entitiy Framework`
- `.NET 5`
- `Xunit`
- `Auto Mapper`
- `JavaScript`
- `BootStrap`
- `MySql`
- `Identity`
- `Angular 13`
- `Angular Material`

## Banco de dados


Banco de dados utilizado no projeto é o MySql provedor de acesso Pomelo;

Ao abrir o projeto, ir para o diretorio SanclerAPI e dar o comando "dotnet ef database update" em seu terminal;

Ele populará o seu banco de dados com as informações necessárias para executar o programa.

Para acesso ao sistema já estará disponível uma conta de admnistrador para utilizar.

- Acesso Administrador:
    Usuário: admin@sancler.com
    senha: admin@123

## Como usar o sistema
### Backend

Para iniciar o sistema primeiro ir no repositório raiz da api do back end nomeada de "SanclerAPI" e dar o comando de "dotnet restore" para atualizar os pacotes e em seguida utilizar "dotnet ef database update";
Proximo passo é executar o dotnet run para iniciar a api do backend;

### Frontend

Com o backend ativo ir no repositório raiz da api do front end nomeada de SanclerAPI - Angular e dar o comando "ng serve".

## BackendAPI

No backend a api foi desenvolvida utilizando o padrão unity of works instanciando o padrão repository, o sistema de autenticação utiliza o JWT Token em conjunto com o Identity para realizar a autorização.
Foi trabalhado com fluent api para modelar os dados no banco de dados e usado dto para fazer as validações de entrada de dados nos controllers.
Criado serviço de cada controller para realizar o desacoplamento da lógica de negócio do controller facilitando os testes.
Criado HATEOAS dos métodos gets.
Aplicado o automapper para fazer o mapeamento dos dtos para as classes de modelo.
Aplicado paginação nos métodos Gets para não sobrecarregar o sistema e nem dar timeout na requisição.
Habilitado Cors para o backend ser consumida por outra api.
Projeto documentado utilizando open api e criado xml para realizar anotações com o swagger.
Utilizado data annotations para criar validação das classes dtos.
Criado testes para testar os retornos das controllers.

<p align="center">
    <img width = "470" src="/img/Backend.PNG">
</p>

## FrontendAPI

Foi utilizado angular 13 para realizar o consumo da api de backend, as requisições foram feitas através do HTTPCLIENT enviando e buscando informações do backend através dos jsons.

### Paginas do usuario

As paginas de acesso do usuário permite que o usuário veja os produtos, entre em contato com o site e veja um pouco mais sobre a empresa, além disso o usuário pode realizar o login na pagina inicial.

A pagina inicial contém um Carousel, navbar e footer para o usuário poder navegar.

pagina inicial:
<p align="center">
    <img width = "470" src="/img/front.PNG">
    <img width = "470" src="/img/front 2.PNG">
</p>

Na pagina de produtos o usuario ao clicar em detalhes é levado para pagina de detalhamento de cada produto.

Para o usuario comum não será permitido acesso ao painel administrativo.

Na barra de navegação superior no canto direito terá a opção do usuario clicar no icone e realizar o logoff ou do usuário adm clicar e ir para o painel administrativo.

<p align="center">
    <img width = "470" src="/img/login.PNG">
</p>

### Paginas do Administrador

Na area do administrador o usuario tem um menu lateral.
<p align="center">
    <img width = "470" src="/img/painel.PNG">
</p>
No menu lateral pode-se navegar pelas seções de "Pagina Inicial" - "Produtos" - "Logout".

Na seção "Pagina Inicial" leva o usuario para a pagina inicial de usuarios.

Na seção "Produtos" o usuario pode ver a lista completa dos categorias cadastrados no sistema, ele pode criar, alterar ou deleta-los além de ter acesso aos dados de cada um como comentários, etoques e avaliações.

Na seção "Logout" o usuário é desconectado do sistema.


****
