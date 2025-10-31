# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

## Back-end(ASP.NET C#)

* **Objetivo** -
  Verificar se as APIs REST estão funcionando conforme o contrato.

* **Ferramenta** -
  Swagger UI

* **Casos de Teste**

  - **Autenticação**

     * Login com credenciais válidas → 200 OK + token
       
  - **CRUD de Hábitos**

     * Criar hábito → 201 Created + payload do novo recurso
     * Listar hábitos → 200 OK + array de objetos
     * Atualizar hábito → 200 OK + payload atualizado
     * Excluir hábito → 204 No Content

* **Evidência**
  Prints do Swagger UI mostrando cada chamada e resposta (sucesso e erro).

* O registro dos Testes Back-end estão registrados em <a href="07-Programação de Funcionalidades.md"> Programação de Funcionalidades</a>

## Front-mobile(React-Native)

* **Objetivo**
  Garantir que a ação iniciada no app percorre todo o fluxo até gravar dados no banco remoto.

* **Ferramentas**

  * Emulador/dispositivo real
  * Gravação de tela
  * Prints

* **Casos de Teste**

| ID | Caso de Teste     | Passos                                                                                                                                   | Critério de Aprovação                                       |
| -- | ----------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------- |
| 01 | Registro de Usuário | 1. Iniciar o Aplicativo;<br> 2. Clicar em "Crie sua conta";<br> 3. Preencha os campos corretamente com nome: Teste, email: Teste@teste.com, senha: SenhaForte123! ;<br> 4. Clique em "Criar Conta". | O app deve redirecionar o usuário a tela inicial. O usuário agora deve estar armazenado corretamente no banco de dados com sua senha criptografada. |
| 02 | Login na Aplicação | 1. Iniciar o Aplicativo;<br> 2. Clicar em "Entrar";<br> 3. Preencha os campos corretamente com email: Teste@teste.com, senha: SenhaForte123! ;<br> 4. Clique em "Entrar".| O app deve redirecionar o usuário a tela inicial. |
| 03 | Criar um Hábito | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Clique no botão "+" localizado na NavBar da aplicação;<br> 3. Clique no botão "Criar um novo hábito";<br> 4. Prencha os campos corretamente com: nome: Beber Água, descrição: Quero me hidratar para ser um bom dev, meta: 3L, frequência: diário; <br> 5. Clique no botão "Criar"| O usuário deve ser redirecionado a página inicial e o hábito criado deve ser vísivel para o usuário. O hábito criado agora deve estar armazenado corretamente no banco de dados. |
| 04 | Atualizar um Hábito | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Na tela inicial, encontre o hábito pendente chamado "Beber Água";<br> 3. Segure e Arraste para a esquerda; <br> 4. Clique no ícone de editar; <br> 5. Altere o nome do hábito para "Beber Café"; 6. Clique em "Salvar". | O usuário deve ser redirecionado para a tela inicial e o hábito anteriormente chamado "Beber Água", agora chama-se "Beber Café". O hábito atualizado deve ser armazenado corretamente no banco de dados, mantendo os outros dados intactos, apenas alterando o que foi pedido.|
| 05 | Excluir um Hábito | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Na tela inicial, encontre o hábito chamado "Beber Café";<br> 3. Segure e Arraste para a direita; <br> 4. Clique em "Sim" para confirmar exclusão do hábito.| O hábito deve desaparecer da tela inicial. O hábito também deve ser completamente excluído do banco de dados. |
| 06 | 	Marcar um Hábito como Concluído | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Na tela inicial, encontre o hábito pendente chamado "Beber Café";<br> 3. Marcar como aoncluído. | O hábito recebe marca visual de concluído e é registrado no progresso do usuário. |
| 07 | 	Editar Perfil | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Acessar perfil;<br> 3. Alterar o nome de exibição ou a imagem;<br> 4. Clicar em salvar. | O hábito recebe marca visual de concluído e é registrado no progresso do usuário. |
| 08 | Configurar Lembrete para Hábito | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Acessar um hábito existente;<br> 3. Definir horário de lembrete (daqui a alguns minutos);<br> 4. Salvar configuração;<br> 5. Esperar até o horário para receber a notificação. | Notificação chega no dispositivo no horário programado. |
| 09 | Completar um Desafio | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Acessar a seção de desafios;<br> 3. Marcar um desafio como concluído. | O desafio é registrado como completo, e o progresso é atualizado na interface. |
| 10 | Seguir Outro Usuário | 1. Iniciar o Aplicativo(O usuário deve estar logado);<br> 2. Acessar o perfil de outro usuário;<br> 3. Clicar em “Seguir”. | Botão muda para “Seguindo” e o ranking de desafios é atualizado com base nos usuários seguidos. |


* **Evidência**
  Vídeo ou sequência de screenshots mostrando:

  1. A interação na UI (toque, preenchimento de formulário)
  2. Resultado final no app e confirmação no banco (retorno via API)

