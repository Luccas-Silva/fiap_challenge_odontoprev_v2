# *Fiap - Challenge Odontoprev* 

##	Projeto FairyTooth: Plataforma de Gestão da Saúde Bucal Personalizada
A proposta é desenvolver uma plataforma digital que centralize as informações dos pacientes, integrando dados clínicos, históricos de tratamentos, hábitos de vida e respostas a questionários de saúde bucal. Essa plataforma funcionaria como um verdadeiro "assistente pessoal" para a saúde bucal, oferecendo:
-	Análise preditiva: Através de algoritmos de machine learning, a plataforma identificaria padrões de comportamento que indicam um maior risco de sinistros, como pacientes que solicitam tratamentos desnecessários ou que apresentam alta rotatividade de dentistas.
-	Recomendações personalizadas: Com base na análise dos dados, a plataforma recomendaria tratamentos preventivos, cuidados específicos e produtos adequados para cada paciente, promovendo a saúde bucal e reduzindo a necessidade de tratamentos mais complexos.
-	Gamificação: A implementação de elementos gamificados, como o sistema de cashback, incentivaria a adesão dos pacientes às recomendações da plataforma e a prática de hábitos saudáveis.
-	Comunicação personalizada: A plataforma permitiria uma comunicação mais próxima e personalizada com os pacientes, através de notificações, lembretes de consultas e materiais educativos.
-	Integração com a rede de dentistas: A plataforma seria integrada à rede de dentistas da Odontoprev, facilitando o agendamento de consultas, o acompanhamento dos tratamentos e a troca de informações entre os profissionais.

## Arquitetura do Projeto: Monolito
Optamos por uma arquitetura monolítica devido à simplicidade e pequeno porte da API. Com poucos controllers e regras de negócio, o monolito facilita a manutenção, a navegação no código e o deploy, sem a complexidade extra dos microservices. Além disso, evita o overhead de comunicação entre serviços e mantém a infraestrutura mais simples. Caso o projeto cresça e demande escalabilidade, podemos reavaliar essa decisão no futuro.

## Clean Architecture
O projeto utiliza a Clean Architecture para promover um código desacoplado, onde cada camada tem responsabilidades bem definidas. Essa abordagem facilita a manutenção e evolução da aplicação.

## Padrão de Criação da API
#### Service Layer (Application Service Pattern)
Camada intermediária entre controllers e repositórios, centralizando regras de negócio.
Uso: Para separar responsabilidades e manter a API modular.
