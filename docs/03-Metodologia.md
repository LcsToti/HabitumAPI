# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

A equipe utiliza a metodologia ágil Scrum para organizar e acompanhar o desenvolvimento do projeto, com ajuda do Kanban do Github. O processo é dividido em sprints de uma semana, com reuniões a cada 3 dias. 

No projeto, usamos o **Git** e **GitHub** como ferramentas de versionamento e organizamos nosso fluxo de trabalho em duas principais branches: **main** e **develop**. A `develop` é a branch onde todo o desenvolvimento acontece, enquanto a `main` sempre contém a versão estável do projeto, pronta para produção. Quando uma issue é iniciada, um branch é criado a partir de develop e o desenvolvedor responsável faz **commits** relacionados à issue específica.

As issues são categorizadas como **bug**, **feat** (novas funcionalidades) e **task** (tarefas gerais), com labels para identificar a prioridade e o tipo de trabalho necessário. Usamos labels como **p0**, **p1** e **p2** para priorização, e **docs**, **test** para especificar o tipo de tarefa. Cada issue é organizada no **Kanban**, onde podemos facilmente visualizar o progresso de cada uma. Além disso, cada issue tem um ou mais assignees, garantindo que as responsabilidades sejam claras.

Para os merges, as alterações são primeiramente feitas nas branches das issues, a partir de develop, e após revisadas, são mescladas (merge) de volta para develop. Quando a develop estiver estável e pronta para produção, é realizada uma merge para a main. Somente os commits realizados nas branches de issues e a partir de develop podem ser mesclados, garantindo que o histórico de versões seja limpo e organizado.

A gerência de commits segue um padrão claro, com mensagens indicando a natureza da mudança, como "feat: add new page layout" ou "fix: remove login bug". Isso facilita o rastreamento e entendimento das alterações feitas no código. Ao final de cada sprint, as issues são fechadas, e a equipe garante que todas as mudanças feitas durante o desenvolvimento foram adequadamente versionadas e documentadas.

O código-fonte é gerenciado no GitHub, seguindo o fluxo de desenvolvimento Git Flow:

- **Branch principal (main)**: Contém a versão estável do projeto.
- **Branch de desenvolvimento (develop)**: Contém as últimas implementações que ainda serão testadas.
- **Branches de feature (Ex: 23-add-notifications-system)**: Criadas para o desenvolvimento de novas funcionalidades.
- **Branches de hotfix (Ex: 55-hotfix-login-error)**: Criadas para correção de erros críticos na produção.

## Relação de Ambientes de Trabalho

| **AMBIENTE**                        | **PLATAFORMA**     | **LINK DE ACESSO**                                                                 |
|-------------------------------------|--------------------|-----------------------------------------------------------------------------------|
| Repositório de código fonte         | GitHub             | https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/tree/main |
| Documentos do projeto               | GitHub             | https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/tree/main/docs |
| Projeto de interface e wireframes   | Figma              | https://www.figma.com/design/9J5FiPcyOFcmmMBI5r4o4p/Habitum---Wireframes?node-id=0-1&t=lmCmPRnOfe5OqfQg-1 |
| Gerenciamento do projeto            | GitHub Projects    | https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/1696 |
| Desenvolvimento de Aplicações Móveis| Expo / React Native| `Link Ainda Indisponível` |
| Backend e API                       | Express + Node.js  | `Link Ainda Indisponível` |
| Banco de Dados                      | MySQL              | `Link Ainda Indisponível` |
| Hospedagem e Infraestrutura         | Azure              | `Link Ainda Indisponível` |

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `develop`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `docs`: melhorias ou acréscimos à documentação
- `test`: relacionado à criação ou melhoria de testes (unitários, integração, etc.)
- `document`: relacionado à criação, edição ou atualização de documentos
- `P0`: prioridade crítica, deve ser resolvido imediatamente
- `P1`: prioridade média, importante mas pode aguardar
- `P2`: prioridade baixa, pode ser feita quando houver tempo disponível
- `Hard!`: tarefa considerada difícil de implementar, necessitando mais atenção

![Captura de tela 2025-03-14 220025](https://github.com/user-attachments/assets/0d488ba0-21f5-48c1-a273-318348cf2530)

## Gerenciamento de Projeto

### Divisão de Papéis

- Scrum Master: Pedro Bezerra;
- Product Owner: Matheus Zeíta;
- Equipe de Desenvolvimento: Pedro Bezerra, Luan Bezerra, Lucas Toti, Pedro Machado e Matheus Zeíta;
- Equipe de Design: Pedro Bezerra, Luan Bezerra, Lucas Toti, Pedro Machado e Matheus Zeíta.

### Processo

- Backlog: Tarefas a serem trabalhadas. Todas as atividades identificadas no decorrer do projeto também devem ser incorporadas a esta lista. 
- Doing: Tarefas que estão sendo desenvolvidas no momento. 
- Review: Quando uma tarefa já tiver sido finalizada e necessita revisão, ela é movida para cá. 
- Done: Nesta lista são colocadas as tarefas que passaram pelos testes e controle de qualidade e estão prontos para ser entregues ao usuário. Não há mais edições ou revisões necessárias, ele está agendado e pronto para a ação.

 O quadro kanban do grupo no GitHub está disponível clicando neste [link](https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/1696)  e é apresentado, no estado atual, na figura abaixo:
 <figure>
  <img src="https://github.com/user-attachments/assets/c17401c6-f677-4b22-b747-b2ddae03a750" <figcaption>Figura 1 - Tela do kanban no GitHub utilizada pelo grupo</figcaption>
</figure>

### Ferramentas

As ferramentas empregadas no projeto são:

- Visual Studio;
- Visual Studio Code;
- Discord;
- Lucidchart;
- Figma;
- Canva;
- Editores de Imagens;
- PowerPoint.

Escolhemos o Visual Studio por sua integração eficiente com o GitHub, enquanto o VS Code foi adotado por seu suporte robusto ao desenvolvimento Front-End. O Discord foi a ferramenta de comunicação essencial para o projeto devido à sua versatilidade e funcionalidade.

Para o desenvolvimento dos slides, utilizamos o PowerPoint e o Canva em conjunto, aproveitando os pontos fortes de cada ferramenta para um resultado mais eficaz.

Na criação e edição de imagens, optamos pelo Canva, que oferece excelentes resultados quando bem utilizado.

Finalmente, para a criação de diagramas, empregamos o Lucidchart em combinação com o Figma. Essa abordagem nos permitiu capturar melhor as necessidades da solução, além de proporcionar maior praticidade no uso.

