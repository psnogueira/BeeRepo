# Projeto Bee - Análise de Dados

**Bee** é uma solução de análise de dados desenvolvida para facilitar o acesso e visualização de informações empresariais através de uma aplicação web. 

Este projeto utiliza: 
- **ASP.NET Core**,
- **SQL Server**;
- **Power BI**

---

![Screenshot_2](https://github.com/user-attachments/assets/47114655-eb2e-4f25-a235-fe356b980d7e)

## Descrição Geral

O projeto **Bee** é uma aplicação web desenvolvida em **C#** utilizando a arquitetura **MVC** do **ASP.NET Core**. Ele permite que os usuários façam consultas e manipulem dados armazenados em um banco de dados **SQL Server** de maneira eficiente. Além disso, a aplicação utiliza **Power BI** para incorporar relatórios diretamente na interface, oferecendo visualizações dinâmicas e interativas.

## Tecnologias Principais

### Linguagem de Programação
- **C#**: A linguagem principal utilizada no desenvolvimento da aplicação.

### Banco de Dados
- **SQL**: Usada para manipulação e consulta dos dados dentro do banco de dados. O banco de dados é gerenciado por **SQL Server**, e administrado através do **SQL Server Management Studio (SSMS) 20**.

### Autenticação e Autorização
- **Identity**: Implementado para o gerenciamento de autenticação e autorização de usuários.

### Integração com Power BI
- **Power BI**: Utilizado para incorporar relatórios do Power BI diretamente na aplicação web. Isso permite que os usuários visualizem gráficos e relatórios interativos dentro da plataforma, sem necessidade de sair da aplicação.

![Screenshot_3](https://github.com/user-attachments/assets/dc89dbcf-3e47-4399-9f2d-8564009ba7e0)

## Estrutura da Aplicação

A aplicação segue o padrão **Model-View-Controller (MVC)**, garantindo uma separação clara entre as responsabilidades de apresentação, lógica de negócios e manipulação de dados. A seguir, uma visão geral da arquitetura da aplicação:

- **Model**: Representa as classes que lidam com a manipulação de dados e a lógica de negócios.
- **View**: Responsável pela apresentação dos dados e pela interação do usuário com o sistema.
- **Controller**: Atua como o intermediário entre o Model e o View, processando as requisições dos usuários e retornando as respostas apropriadas.

## Funcionalidades Principais

### 1. Autenticação e Autorização
O projeto **Bee** utiliza o **ASP.NET Core Identity** para gerenciar o acesso de usuários. Isso inclui:
- Registro de novos usuários.
- Login seguro com criptografia de senhas.
- Controle de permissões para diferentes funcionalidades e dados baseados no perfil do usuário.

### 2. Análise de Dados com Power BI
Com a integração do **Power BI Embedded**, o projeto oferece:
- Visualização de relatórios dinâmicos diretamente na interface da aplicação.
- Atualização em tempo real dos relatórios utilizando dados do banco de dados SQL Server.
- Relatórios customizáveis baseados nos dados filtrados ou selecionados pelo usuário.

### 3. Manipulação e Consulta de Dados
A aplicação permite que os usuários:
- Consultem dados armazenados no banco de dados utilizando **SQL**.
- Filtrar e visualizar informações importantes com base em relatórios gerados pelo Power BI.

## Estrutura de Pastas

```
Bee/
├── Areas/Identity/Pages
├── Controllers
├── Data
├── Models
├── Pages
├── Pagination
├── Properties
├── Repository
├── Views
├── wwwroot
├── Bee.csproj
├── Program.cs
├── appsettings.Development.json
├── appsettings.json
```

## Descrição de Cada Pasta/Arquivo

#### 1. **Areas/Identity/Pages**
   Esta pasta é criada automaticamente pelo ASP.NET Core quando a autenticação e autorização são configuradas com **ASP.NET Core Identity**. Dentro dela, ficam as páginas relacionadas à autenticação de usuários, como:
   - Login, registro, recuperação de senha.
   - Perfis de usuários.
   - Gerenciamento de senhas e confirmações de e-mail.

#### 2. **Controllers**
   Armazena os controladores da aplicação, que são responsáveis por processar as requisições HTTP e decidir quais respostas enviar para o cliente. No modelo **MVC**, os controladores atuam como intermediários entre as **Views** (páginas HTML) e os **Models** (dados). Cada controlador manipula uma parte específica do fluxo de aplicação, como a lógica de manipulação de dados ou o controle de navegação da aplicação.

#### 3. **Data**
   Contém as classes e configurações que gerenciam o acesso ao banco de dados. Isso pode incluir:
   - **Contexto do banco de dados**: a classe derivada de `DbContext` que gerencia as entidades e as consultas ao banco de dados usando **Entity Framework Core**.
   - Scripts de migração, se aplicável.
   - Configurações de inicialização e semente de dados.

#### 4. **Models**
   Armazena as classes de **Model**, que representam os objetos de domínio da aplicação, ou seja, os dados que serão manipulados. No padrão **MVC**, os **Models** são responsáveis pela lógica de negócios e por acessar o banco de dados. Um **Model** pode representar uma tabela do banco de dados, como usuários, produtos ou relatórios.

#### 5. **Pages**
   No ASP.NET Core, essa pasta é usada para **Razor Pages**, uma abordagem alternativa ao MVC tradicional para construir páginas web dinâmicas. Aqui, você pode encontrar arquivos de páginas `.cshtml` que contêm a lógica de interface e apresentação da aplicação. **Razor Pages** facilitam a criação de páginas que combinam HTML e C# de forma eficiente.

#### 6. **Pagination**
   Contém a lógica relacionada à paginação de dados, útil quando há muitos registros no banco de dados. Essa pasta contém:
   - Componentes responsáveis por implementar a paginação.
   - Métodos que ajudam a dividir grandes conjuntos de dados em páginas menores.

#### 7. **Properties**
   Contém arquivos de configuração específicos do projeto, como o `launchSettings.json`, que define perfis de inicialização da aplicação durante o desenvolvimento. Ele especifica o ambiente de desenvolvimento, portas, e opções de inicialização para o servidor web local.

#### 8. **Repository**
   Esta pasta armazena o **padrão Repository**, que abstrai a lógica de acesso a dados e facilita o gerenciamento dos dados. O uso de repositórios separa as consultas ao banco de dados da lógica de negócios e permite a troca mais fácil da camada de persistência (como mudar o banco de dados).

#### 9. **Views**
   Armazena as **Views** do padrão MVC, que são responsáveis pela apresentação dos dados ao usuário. As Views contêm arquivos `.cshtml`, que são páginas HTML combinadas com a linguagem de marcação **Razor**, permitindo que você insira código C# diretamente nas páginas HTML.
   - Cada controlador terá sua própria subpasta dentro de **Views** com as páginas associadas às suas ações.

#### 10. **wwwroot**
   Essa é a pasta pública da aplicação, onde são armazenados os arquivos estáticos acessíveis diretamente pelo navegador, como:
   - **CSS**: Arquivos de estilo da aplicação.
   - **JavaScript**: Scripts front-end.
   - **Imagens**: Logos, ícones e outras imagens utilizadas na interface.
   - Outros recursos estáticos como fontes ou arquivos de bibliotecas externas.

## Arquivos Principais

#### 11. **Bee.csproj**
   Este é o arquivo do **projeto** do .NET Core. Ele define todas as dependências, versões do SDK, frameworks e pacotes NuGet utilizados pela aplicação. Também especifica informações sobre a build do projeto e quais arquivos devem ser incluídos ou excluídos.

#### 12. **Program.cs**
   O ponto de entrada da aplicação. É aqui que a configuração inicial ocorre, como a definição do servidor web, a configuração dos serviços (como injeção de dependências) e o middleware da aplicação. Ele configura o pipeline de execução e prepara a aplicação para rodar.

#### 13. **appsettings.Development.json**
   Este arquivo contém configurações específicas para o ambiente de **desenvolvimento**. Ele é uma extensão do `appsettings.json` e permite que você sobrescreva configurações quando a aplicação estiver sendo executada localmente, como a string de conexão com o banco de dados de desenvolvimento.

#### 14. **appsettings.json**
   Arquivo de configuração principal da aplicação. Ele contém definições globais como:
   - **Strings de conexão** com o banco de dados.
   - Configurações de logging.
   - Chaves de API.
   - Configurações específicas do ambiente de produção ou staging.

---

### Resumo
Esta estrutura reflete uma aplicação **ASP.NET Core** organizada, que segue o padrão **MVC**, usando **Razor Pages** para as views, com foco em boa separação de responsabilidades. O projeto utiliza **Entity Framework** para manipulação de dados e abstração de consultas ao banco de dados SQL, além de **ASP.NET Core Identity** para gerenciamento de autenticação e autorização. As funcionalidades de paginação e repositório também são organizadas para garantir um fluxo de dados eficiente e escalável.

## Licença


