# *Java Advanced - Challenge Odontoprev* 

## Sumário
- [Objetivo do Projeto](#projeto-fairytooth-plataforma-de-gestão-da-saúde-bucal-personalizada)
- [Diagrama de Relacionamento (DER)](#diagrama-de-relacionamento-der)
- [Instrução para rodar a aplicação](#instrução-para-rodar-a-aplicação)
- [Listagem de endpoints (Doc API)](#listagem-de-endpoints-doc-api)

##	Projeto FairyTooth: Plataforma de Gestão da Saúde Bucal Personalizada
A proposta é desenvolver uma plataforma digital que centralize as informações dos pacientes, integrando dados clínicos, históricos de tratamentos, hábitos de vida e respostas a questionários de saúde bucal. Essa plataforma funcionaria como um verdadeiro "assistente pessoal" para a saúde bucal, oferecendo:
-	Análise preditiva: Através de algoritmos de machine learning, a plataforma identificaria padrões de comportamento que indicam um maior risco de sinistros, como pacientes que solicitam tratamentos desnecessários ou que apresentam alta rotatividade de dentistas.
-	Recomendações personalizadas: Com base na análise dos dados, a plataforma recomendaria tratamentos preventivos, cuidados específicos e produtos adequados para cada paciente, promovendo a saúde bucal e reduzindo a necessidade de tratamentos mais complexos.
-	Gamificação: A implementação de elementos gamificados, como o sistema de cashback, incentivaria a adesão dos pacientes às recomendações da plataforma e a prática de hábitos saudáveis.
-	Comunicação personalizada: A plataforma permitiria uma comunicação mais próxima e personalizada com os pacientes, através de notificações, lembretes de consultas e materiais educativos.
-	Integração com a rede de dentistas: A plataforma seria integrada à rede de dentistas da Odontoprev, facilitando o agendamento de consultas, o acompanhamento dos tratamentos e a troca de informações entre os profissionais.

## Diagrama de Relacionamento (DER)

![image](https://github.com/user-attachments/assets/684c9e4d-141f-4fe4-89cc-6e088574758b)
![image](https://github.com/user-attachments/assets/64a41d1e-612f-4e95-ae2a-d8807e5e7cb6)

## Instrução para rodar a aplicação

Para configurar sua aplicação, acesse o arquivo `application.properties`. Neste arquivo, você encontrará propriedades que permitem personalizar o comportamento da sua aplicação.
Para conectar ao banco de dados, localize as propriedades username password. Nestas propriedades, insira respectivamente o nome de usuário e a senha para acessar o seu banco de dados. 

### Exemplo:
```
{
  datasource:
  url: jdbc:oracle:thin:@oracle.fiap.com.br:1521:orcl
  username: usuario
  password: senha
  driver-class-name: oracle.jdbc.OracleDriver
  jpa:
  hibernate:
  ddl-auto: create
  database-platform: org.hibernate.dialect.OracleDialect
}
```
Após realizar as alterações, salve o arquivo e execute a aplicação. A aplicação utilizará as novas credenciais para se conectar ao banco de dados.

## Listagem de endpoints (Doc API)

### Cliente
* **GET /cliente/lista**: Listar Clientes
* **POST /cliente/novo:** Criar Cliente
* **PUT /cliente/editar/{clienteId}**: Editar Cliente
* **DELETE /cliente/deletar/{clienteId}**: Deletar Cliente


### Dentista
* **GET /dentista/listas**: Listar Dentista
* **POST /dentista/novo:** Criar Dentista
* **PUT /dentista/editar/{dentistaId}**: Editar Dentista
* **DELETE /dentista/deletar/{dentistaId}**: Deletar Dentista

### Consulta
* **GET /consulta/listas**: Listar Consulta
* **POST /consulta/novo:** Criar Consulta
* **PUT /consulta/editar/{consultaId}**: Editar Consulta
* **DELETE /consulta/deletar/{consultaId}**: Deletar Consulta
