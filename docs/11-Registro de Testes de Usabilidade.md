# Registro de Testes de Usabilidade
<span style="color:red">Pré-requisitos: <a href="10-Plano de Testes de Usabilidade.md"> Plano de Testes de Usabilidade</a></span>

| # | Tarefas                                                               | Critério de Sucesso                        | Tempo Máximo |
|---|------------------------------------------------------------------------|--------------------------------------------|--------------|
| 1 | Criar uma conta | O usuário deve criar uma conta corretamente, sendo redirecionado para a página inicial | 1 minuto e 30 segundos   |
| 2 | Fazer Login | O usuário deve fazer login em uma conta existente, sendo redirecionado para a página inicial | 1 minuto |
| 3 | Criar um hábito | O usuário deve criar um hábito corretamente e ele deve ser visível na página inicial | 3 minutos    |
| 4 | Atualizar um hábito | O usuário deve atualizar um hábito existente e ele deve ser atualizado corretamente | 2 minutos    |
| 5 | Excluir um hábito | O hábito deve ser removido da tela inicial. | 40 segundos |
|6|	Marcar um hábito como concluído	|O usuário deve marcar um hábito existente como concluído e ele deve ser visualmente atualizado.	|30 segundos|
|7|	Editar o perfil	|Usuário atualiza os dados do perfil e as alterações são salvas corretamente, com confirmação visual	|2 minutos|
|8|	Configurar lembrete para hábito	|Usuário configura o horário de lembrete para certo hábito e o aplicativo o notifica no seu dispositivo no horário determinado	|5 minutos|
|9|	Completar os desafios	|Usuário marca um desafio como concluído e vê o progresso atualizado no aplicativo|	2 minutos|
|10|	Seguir outro usuário	|Usuário começa a seguir outro usuário e o ranking de desafios é atualizado|	2 minutos|

#### Tabela de Execução

| Tarefa | Nome do Participante | Avaliação Heurística (0–4) | Comentários/Dificuldades                                                                | Tempo Gasto    |
| ------ | -------------------- | -------------------------- | --------------------------------------------------------------------------------------- | -------------- |
| 1      | Pedro                | 3                          | A estética é boa, mas os erros são genéricos. Não informa quais campos estão inválidos. | 1 minuto       |
| 7      | Bruno     | 0                          | Nada a declarar                        | 1 minuto e 20s  |
| 8      | Larissa   | 0                          | Nada a declarar                        | 4 minutos e 30s |
| 9      | Marcelo    | 0                          | Nada a declarar                        | 1 minuto e 45s  |
| 2      | Pedro                | 2                          | Falta validação melhor. Mensagens de erro muito genéricas.                              | 30 segundos    |
| 3      | Luan                 | 1                          | O botão "Criar" está muito embaixo, difícil de achar.                                   | 1 minuto       |
| 1      | Gustavo      | 0                          | Nada a declarar                        | 1 minuto        |
| 2      | Bianca      | 0                          | Nada a declarar                        | 50 segundos     |
| 4      | Luan                 | 1                          | O botão "Atualizar" também está mal posicionado. Pode ir pro topo da tela.              | 45 segundos    |
| 5      | Luan                 | 0                          | Muito bom. Rápido e direto.                                                             | 10 segundos    |
| 6      | Matheus              | 2                          | A ação de marcar como feito é pouco intuitiva. Ícone pequeno.                           | 40 segundos    |
| 7      | Pedro                | 3                          | Formulário claro, mas poderia haver confirmação tipo toast.                             | 1 minuto e 30s |
| 8      | Matheus              | 1                          | Interface confusa na hora de configurar o horário. Feedback fraco.                      | 4 minutos      |
| 4      | Juliana        | 0                          | Nada a declarar                        | 35 segundos     |
| 5      | Diego       | 0                          | Nada a declarar                        | 20 segundos     |
| 6      | Fernanda     | 0                          | Nada a declarar                        | 25 segundos     |
| 9      | Luan                 | 2                          | Sistema de desafios funcional, mas falta clareza no feedback visual após concluir.      | 1 minuto e 40s |
| 10     | Pedro                | 3                          | Funciona bem, mas o botão para seguir é pequeno e pouco visível.                        | 1 minuto e 20s |
| 3      | Rafael      | 0                          | Nada a declarar                        | 2 minutos       |
| 10     | Patrícia      | 0                          | Nada a declarar                        | 1 minuto        |



## Resumo dos Resultados `Atualizado em: 11/05/2025`

| **Tarefa** | **Taxa de Sucesso (%)** | **Tempo Médio**     | **Média Heurística** | **Principais Dificuldades**                       |
| ---------: | ----------------------- | ------------------- | -------------------- | ------------------------------------------------- |
|          1 | 100%                    | **1 minuto**        | **1,5**              | Erros genéricos em validação                      |
|          2 | 100%                    | **40 segundos**     | **1,0**              | Erros genéricos, falta de validação               |
|          3 | 100%                    | **1 minuto e 30s**  | **0,5**              | Botão "Criar" mal posicionado                     |
|          4 | 100%                    | **40 segundos**     | **0,5**              | Botão "Atualizar" escondido                       |
|          5 | 100%                    | **15 segundos**     | **0,0**              | Nenhuma                                           |
|          6 | 100%                    | **32,5 segundos**   | **1,0**              | Ícone pequeno e pouco intuitivo                   |
|          7 | 100%                    | **1 minuto e 25s**  | **1,5**              | Falta de confirmação visual                       |
|          8 | 100%                    | **4 minutos e 15s** | **0,5**              | Interface confusa, pouco feedback visual          |
|          9 | 100%                    | **1 minuto e 42s**  | **1,0**              | Falta clareza no feedback após concluir o desafio |
|         10 | 100%                    | **1 minuto e 10s**  | **1,5**              | Botão de seguir pequeno e pouco destacado         |

