# Programação de Funcionalidades

## 📌 Última vez atualizado

> Atualizado em: `11/05/2025`

## 🔧 Desenvolvimento Atual de Telas

| Tela                              | Status                 | Responsável        |
|-----------------------------------|------------------------|--------------------|
| Tela Inicial                      | ✅ Concluída           | Pedro Bezerra, Luan Bezerra   |
| Tela de Login                     | ✅ Concluída           | Pedro Bezerra, Luan Bezerra   |
| Tela de Registro                  | ✅ Concluída           | Matheus Zeita, Luan Bezerra   |
| Tela de Configuração da Conta     | ✅ Concluída           | Lucas Toti, Luan Bezerra        |
| Tela Principal                    | ✅ Concluída           | Pedro Machado, Lucas Toti     |
| Tela de Predefinições de Hábitos  | ✅ Concluída           | Luan Bezerra      |
| Tela de Criação de Hábito         | ✅ Concluída           | Pedro Bezerra     |
| Tela da Comunidade                | ✅ Concluída           | Lucas Toti        |
| Tela de Desafios                  | ✅ Concluída           | Pedro Machado     |
| Tela de Perfil                    | ✅ Concluída           | Matheus Zeita     |


## 🔧 Desenvolvimento Atual de Funcionalidades

- ✅ Concluída - Já implementada
- 🚧 Em andamento - Em fase de planejamento/desenvolvimento
- 📋 Backlog - Em breve será implementado
- 🛑 Bloqueada - Não será implementado

| Funcionalidade | Descrição | Status | Responsável |
|----------------|-----------|--------|-------------|
| Criação de Conta | Permite que o usuário crie uma nova conta (RF-01) | ✅ Concluída | Lucas Toti, Luan Bezerra |
| Login de Usuário | Permite que o usuário faça login em uma conta existente (RF-02) | ✅ Concluída | Luan Bezerra |
| Cadastro de Hábitos | Permite que o usuário cadastre novos hábitos e tarefas (RF-03) | ✅ Concluída | Pedro Bezerra |
| Customização de Hábitos | Permite a personalização de hábitos pelo usuário (RF-04) | ✅ Concluída | Pedro Machado |
| Exclusão de Hábitos | Permite que o usuário exclua hábitos cadastrados (RF-05) | ✅ Concluída | Pedro Machado |
| Marcar Tarefa como Concluída | Permite marcar tarefas como feitas (RF-15) | ✅ Concluída | Lucas Toti |
| Mostrar Tarefas Diárias/Semanais | Exibe as atividades programadas pelo usuário (RF-13) | ✅ Concluída | Lucas Toti |
| Temporizador de Tarefas | Fornece um cronômetro para realização de tarefas (RF-06) | 🛑 Bloqueada |  |
| Lembretes de Tarefas | Envia notificações sobre tarefas programadas (RF-07) | ✅ Concluída | Pedro Bezerra |
| Hábitos Predefinidos | Sugere hábitos com base na escolha do usuário (RF-08) | ✅ Concluída | Luan Bezerra |
| Desafios e Recompensas | Oferece desafios e recompensas como incentivo (RF-09) | 🚧 Em andamento | Pedro Bezerra |
| Seguir Usuários | Permite que o usuário siga outros usuários (RF-10) | ✅ Concluída | Pedro Machado, Lucas Toti |
| Sistema de Ranqueamento | Exibe classificação dos usuários (RF-11) | ✅ Concluída | Lucas Toti, Pedro Bezerra |
| Sistema de Pontuação | Atribui pontos para hábitos/tarefas concluídas (RF-12) | ✅ Concluída | Lucas Toti, Pedro Bezerra |
| Compartilhamento de Resultados | Permite que o usuário compartilhe seus resultados (RF-14) | 🛑 Bloqueada |  |
| Contador de Sequência | Exibe a sequência de dias com hábitos cumpridos (RF-16) | ✅ Concluída | Lucas Toti |

## 🔎 Evidências de Implementação das Funcionalidades de CRUD e Autenticação

### Evidência de CRUD
- Na fase atual do projeto temos as funções de CRUD implementadas, são elas: Criar, Exibir, Editar e Deletar.
![image](https://github.com/user-attachments/assets/38f908b1-f770-452f-97c3-9c3e70a1b633)

- As evidências a seguir utilizam o swagger para fazer a validação e mostrar elas que estão funcionando como deveriam.

#### Evidência de CRUD #1 - Criar
> Criação de um novo hábito.

![image](https://github.com/user-attachments/assets/ca9834ca-cc99-452d-b123-acf0aaad0240)

#### Evidência de CRUD #2 - Exibir
> Exibe detalhes de um hábito.

![image](https://github.com/user-attachments/assets/3e05c0b4-a04a-4687-b857-0e2271fa0c0a)

#### Evidência de CRUD #3 - Editar
> Editar um hábito já existente.

![image](https://github.com/user-attachments/assets/8ea4dae4-a7b8-41dd-a5ab-08cb67a22e3f)

#### Evidência de CRUD #4 - Deletar
> Deleta i, hábito ja existente.

![image](https://github.com/user-attachments/assets/46092a9b-5b9c-47cb-81f8-6005a9b8f964)

### Evidência de autenticação
- Implementamos autenticação via JWT Bearer neste projeto.
- As evidências a seguir utilizam o swagger para fazer a validação e mostrar elas que estão funcionando como deveriam.

#### Evidência de autenticação
> Login de um usuário retorna um token.

![image](https://github.com/user-attachments/assets/2090563f-2acf-4145-a0b6-db6c4f37c989)

> Verificando se o token é válido.

![image](https://github.com/user-attachments/assets/71c72f57-f97b-4d58-ada6-400decafe6d2)


## 📊 Gerenciamento Visual do Trabalho Atual

- **Quadro Kanban:** [Habitum KANBAN]([#](https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/1696/views/1))
- **Sprint atual:** Etapa 4 - Continuidade do Desenvolvimento da Solução: Desenvolvimento da aplicação móvel (Parte 1) (06/04/25 a 11/05/25)

---

## 👥 Status das Contribuições no GitHub

| Membro            | Contribuições                                                                                     |
|-------------------|---------------------------------------------------------------------------------------------------|
| **Lucas Toti**    | Reestruturou a arquitetura do backend, implementou streaks, desafios, recompensas, push notifications, API de comunidade, correções de bugs, melhorias em validações, refactor no front e exportação de hábitos. |
| **Matheus Zeita** | Atuou no Profile.tsx, deu suporte no front e ajustes finos em componentes. |
| **Pedro Machado** | Trabalhou nos desafios, atualizações/deleções de hábitos e ajustes em endpoints do back e front. |
| **Luan Bezerra**  | Cuidou da autenticação, CRUD inicial, refactor em páginas de login/cadastro e validações.|
| **Pedro Bezerra** | Criou o fluxo de criação de hábitos (back e front), testou integrações e ajudou no controle de qualidade do time. |
---

## 🗒️ Comentários Adicionais sobre as Contribuições Individuais

| Membro            | Comentários                                                                                         |
|-------------------|-----------------------------------------------------------------------------------------------------|
| **Lucas Toti**    | O efeito borboleta em forma de dev: muda um botão e magicamente surgem cinco pastas novas, três bugs resolvidos que ninguém notou antes e um sistema ainda mais robusto. |
|**Matheus Zeita**  | Ninja silencioso. Some por dias, mas quando aparece, dropa um commit do nada e sai andando como se nada tivesse acontecido. Misterioso, porém funcional.|
| **Pedro Machado** | É o cara que só queria arrumar um botão e acabou descobrindo que o login quebra quando é terça-feira e chove. Insubstituível na arte de achar problema onde ninguém olha.|
| **Luan Bezerra**  | Cada botão desalinhado é uma ofensa pessoal. O único capaz de abrir o Figma só pra dizer “isso aqui tá feio”. Só falta tatuar “padding é vida” no braço.|
| **Pedro Bezerra** | Entregou o MVP antes de todo mundo pensar em abrir o VS Code. Agora virou o fiscal de produtividade alheia — se você atrasou, ele sabe. Uma mistura de dev com gerente de projeto não-oficial.|



