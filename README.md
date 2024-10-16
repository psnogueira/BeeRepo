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

## Licença


