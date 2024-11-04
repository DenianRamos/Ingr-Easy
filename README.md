# IngrEasy


## Índice

- [Descrição](#descrição)
- [Funcionalidades](#funcionalidades)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Testes](#testes)
- [Contribuições](#contribuições)
- [Licença](#licença)

## Descrição

**IngrEasy** é uma solução simples e eficiente para gerenciar ingredientes e receitas. Com ele, você pode controlar o estoque de ingredientes, criar e organizar receitas de forma prática e monitorar a quantidade dos ingredientes disponíveis para evitar desperdícios e melhorar a organização.

## Funcionalidades

- **Gestão de Ingredientes**: Registre e mantenha atualizado o estoque de ingredientes.
- **Criação de Receitas**: Crie receitas detalhadas com os ingredientes e quantidades necessários.
- **Controle de Estoque**: Monitore o estoque dos ingredientes e saiba quando é necessário reabastecer.

## Estrutura do Projeto

A estrutura do projeto foi pensada para manter as responsabilidades bem definidas e facilitar o desenvolvimento e a manutenção:

- `src/Backend/IngrEasy.API`  
  Contém a API do projeto, responsável por expor os endpoints.

- `src/Backend/IngrEasy.Domain`  
  Define as entidades e regras de domínio.

- `src/Backend/IngrEasy.Infrastructure`  
  Lida com a infraestrutura e persistência de dados.

- `src/Backend/IngrEasy.Application`  
  Contém a lógica de aplicação, intermediando o domínio e a infraestrutura.

- `src/Shared/IngrEasy.Exception`  
  Gerencia as exceções que são compartilhadas pelo projeto.

- `IngrEasy.Communication`  
  Inclui classes e serviços de comunicação.

- `tests`  
  Reúne os testes do projeto, assegurando que todas as funcionalidades estejam funcionando como esperado.

## Instalação

1. Clone este repositório:
   ```bash
   git clone https://github.com/DenianRamos/Ingr-Easy.git
