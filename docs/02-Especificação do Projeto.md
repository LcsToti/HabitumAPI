# Especificações do Projeto

Tópicos:
- [Personas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#personas)
- [História de Usuários](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#hist%C3%B3rias-de-usu%C3%A1rios)
- [Modelagem do Processo de Negócio](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#modelagem-do-processo-de-neg%C3%B3cio)
- [Requisitos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#requisitos) 
- [Diagrama de Casos de Uso](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#diagrama-de-casos-de-uso)
- [Matriz de Rastreabilidade](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#matriz-de-rastreabilidade)
- [Gerenciamento do Projeto](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e3-proj-mov-t4-habitum/blob/main/docs/02-Especifica%C3%A7%C3%A3o%20do%20Projeto.md#gerenciamento-de-projeto)

## Personas

| Foto | Persona |
|------|---------|
| <img src="https://github.com/user-attachments/assets/e5f097ff-c968-41cb-a026-bb1820dbb68d" width="150"/> | **João, 17 anos, Estudante do Ensino Médio**<br><br>• **Objetivo:** Melhorar a disciplina nos estudos para o vestibular e evitar distrações como redes sociais e jogos.<br>• **Problema:** Sente dificuldade em manter uma rotina de estudos consistente e sempre adia tarefas para o último momento.<br>• **Comportamento:** Passa muito tempo no celular, se distrai facilmente e procrastina ao estudar. Gosta de desafios e recompensas.<br>• **Motivação:** Criar um cronograma de estudos e manter a disciplina por meio de recompensas gamificadas. |
| <img src="https://github.com/user-attachments/assets/09b8fbee-cd97-4792-93ae-b1ee4fccba6c" width="150"/> | **Lucas, 29 anos, Programador**<br><br>• **Objetivo:** Melhorar hábitos saudáveis, como atividade física e sono regular, sem comprometer o trabalho.<br>• **Problema:** Fica horas seguidas no computador, procrastina atividades físicas e não tem um horário fixo para dormir.<br>• **Comportamento:** Gosta de tecnologia e gamificação, mas sente que o excesso de tempo online prejudica seu bem-estar.<br>• **Motivação:** Usar um sistema de recompensas para manter uma rotina mais equilibrada entre trabalho e vida pessoal. |
| <img src="https://github.com/user-attachments/assets/8c64aee1-e9ca-4dfc-94d8-e49fcbbe5bcc" width="150"/> | **Beatriz, 22 anos, Universitária e Estagiária**<br><br>• **Objetivo:** Organizar melhor sua rotina entre faculdade, estágio e vida pessoal.<br>• **Problema:** Se sente sobrecarregada e procrastina tarefas da faculdade devido ao cansaço do estágio.<br>• **Comportamento:** Planeja sua rotina, mas acaba deixando de seguir o plano por falta de motivação. Costuma esquecer prazos de trabalhos.<br>• **Motivação:** Receber lembretes personalizados e usar recompensas para manter a motivação nos estudos e no trabalho. |




## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| João | Um cronograma de estudos gamificado com recompensas | Melhorar minha disciplina |
| João | Desafios e recompensas por metas de estudo cumpridas | Me manter motivado e tornar o estudo mais interessante |
| Lucas | Lembretes para pausas e exercícios físicos | Evitar ficar horas seguidas no computador e melhorar minha saúde |
| Lucas | Um temporizador personalizado das minhas pausas | Equilibrar melhor trabalho e vida pessoal |
| Beatriz | Receber lembretes das minhas tarefas | Não esquecer de fazê-las |
| Beatriz | Estatísticas de tarefas pendentes/concluídas | Entender quais tarefas priorizar |

## Modelagem do Processo de Negócio 

### Análise da Situação Atual

Atualmente, muitas pessoas enfrentam dificuldades para criar e manter hábitos saudáveis devido ao excesso de distrações digitais.
A procrastinação é um problema crescente, intensificado pelo uso constante de redes sociais e estímulos rápidos.
Não existe uma ferramenta eficaz que combine gamificação, recompensas e lembretes personalizados para manter os usuários engajados.

### Descrição Geral da Proposta

O aplicativo propõe um sistema gamificado que incentiva a criação de hábitos saudáveis.
Oferece lembretes inteligentes, um sistema de recompensas e acompanhamento de progresso para combater a procrastinação.
Ele busca tornar o processo de criação de hábitos mais envolvente e menos frustrante.

### Processo 1 – Cadastro e Configuração de Hábitos

O usuário define um novo hábito e ajusta as configurações.

![image](https://github.com/user-attachments/assets/6a886129-65e4-4cc7-918d-8e8673f019ac)


### Processo 2 – Envio de Lembretes Automáticos

O sistema envia notificações no momento ideal. Algoritmo que se adapta, notificações contextuais.

![image](https://github.com/user-attachments/assets/db63b6a7-c673-4c4b-850d-68964f97d6d1)

### Processo 3 – Recompensas e Pontuação

O usuário recebe pontos ao cumprir hábitos. Dinâmica envolvente, motiva o usuário a cumprir seus objetivos.

![image](https://github.com/user-attachments/assets/db26af87-5e81-4df2-81d8-146e38f82bcd)


## Indicadores de Desempenho

![{78D4CC84-8AF7-43F8-994D-CB597AD868B7}](https://github.com/user-attachments/assets/4b6ddc13-ebce-405c-8afd-31ca7cdeb28d)


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade | Estabilidade | Status |
|-------|------------------------|----|----|---|
|RF-01| A aplicação deve permitir que o usuário crie uma nova conta | Must | Estável | Concluído  |
|RF-02| A aplicação deve permitir que o usuário logue em uma conta já existente | Must | Estável | Concluído  |
|RF-03| A aplicação deve permitir o cadastro de hábitos e tarefas | Must | Estável | Concluído  |
|RF-04| A aplicação deve permitir a customização de hábitos | Must | Estável | Concluído  |
|RF-05| A aplicação deve permitir a exclusão de hábitos | Must | Estável | Concluído  |
|RF-06| A aplicação deve fornecer um temporizador para realização de tarefas | Won't | Estável | Em Análise |
|RF-07| A aplicação deve fornecer lembretes das tarefas para os usuários | Should | Estável | Em Desenvolvimento |
|RF-08| A aplicação deve fornecer hábitos predefinidos para o usuário | Should |  Estável | Em Desenvolvimento |
|RF-09| A aplicação deve fornecer desafios e recompensas para os usuários | Could | Estável | Implementado |
|RF-10| A aplicação deve permitir que um usuário siga outros | Should | Estável | Em Desenvolvimento |
|RF-11| A aplicação deve fornecer um sistema de ranqueamento para os usuários | Should | Estável | Implementado |
|RF-12| A aplicação deve ter um sistema de pontuação | Should | Estável | Implementado |
|RF-13| A aplicação deve mostrar os hábitos e tarefas do dia programados pelo usuário | Must | Estável | Concluído |
|RF-14| A aplicação deve permitir que o usuário compartilhe seus resultados | Won't | Estável | Em análise |
|RF-15| A aplicação deve permitir que o usuário marque sua tarefa como concluída | Must | Estável | Concluído |
|RF-16| A aplicação deve fornecer um contador da sequência de dias que o usuário cumpriu hábitos | Must | Estável | Concluído |

### Requisitos não Funcionais

|ID    | Descrição do Requisito  | Prioridade | Estabilidade |
|------|------------------------|----|----|
|RNF-01| A aplicação deve funcionar em Android e IOS | Must | Estável | 
|RNF-02| A aplicação deve ser responsiva em dispositivos móveis | Should | Estável | 
|RNF-03| A aplicação deve manter as informações do usuário de acordo com a LGPD | Must | Estável | 
|RNF-04| A aplicação deve respeitar o fuso horário do usuário | Must | Estável |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |

## Diagrama de Casos de Uso

![image](https://github.com/user-attachments/assets/58f9b8b2-43b1-437e-b568-2f84f606d507)


# Matriz de Rastreabilidade

A matriz de rastreabilidade é uma ferramenta usada para facilitar a visualização dos relacionamento entre requisitos e outros artefatos ou objetos, permitindo a rastreabilidade entre os requisitos e os objetivos de negócio. 
A matriz deve contemplar todos os elementos relevantes que fazem parte do sistema.

![Matriz de Rastreabilidade](https://github.com/user-attachments/assets/d571dc9e-8b23-4238-8a0e-157564c592b6)

# Gerenciamento de Projeto

De acordo com o PMBoK v6 as dez áreas que constituem os pilares para gerenciar projetos, e que caracterizam a multidisciplinaridade envolvida, são: Integração, Escopo, Cronograma (Tempo), Custos, Qualidade, Recursos, Comunicações, Riscos, Aquisições, Partes Interessadas. Para desenvolver projetos um profissional deve se preocupar em gerenciar todas essas dez áreas. Elas se complementam e se relacionam, de tal forma que não se deve apenas examinar uma área de forma estanque. É preciso considerar, por exemplo, que as áreas de Escopo, Cronograma e Custos estão muito relacionadas. Assim, se eu amplio o escopo de um projeto eu posso afetar seu cronograma e seus custos.

## Gerenciamento de Tempo

![Habitum Planilha Gantt 1](https://github.com/user-attachments/assets/2982c887-7d49-4019-bddc-55fbe26fda15)

![Habitum Planilha Gantt 2](https://github.com/user-attachments/assets/27d036e7-9ff2-4775-b88c-896255564474)


## Gerenciamento de Equipe

O gerenciamento adequado de tarefas contribuirá para que o projeto alcance altos níveis de produtividade. Por isso, é fundamental que ocorra a gestão de tarefas e de pessoas, de modo que os times envolvidos no projeto possam ser facilmente gerenciados. 

![Planejamento de Equipe](https://github.com/user-attachments/assets/202b818e-e709-4d56-b10a-d5723a12f93c)

## Gestão de Orçamento

|Recursos necessários|(R$)|
|--------------------------------|-------------------|
|Recursos humanos|35.000,00|
|Hardware|6.000,00|
|Rede|2.500,00|
|Software|8.000,00|
|Serviços|15.000,00|
|TOTAL|66.500,00|

