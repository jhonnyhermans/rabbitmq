
# rabbitmq

.Net Core, RabbitMQ in Docker
#### JH.RabbitMq.Publisher  
Cosulta dados da API de previsão de tempo Advisor (https://advisor.climatempo.com.br/), publica o mensagem com o resultado pelo RabbitMQ.
#### JH.RabbitMq.Publisher
Recebe a mensagem publicada pelo JH.RabbitMq.Publisher, trata os dados e persiste em uma base de dados SQL Server.

### Instalação
#1 - Instalar Docker - https://www.docker.com/docker-windows

#2 - Executar comando para criar container RabbitMQ no docker
     
     docker run -d --hostname rabbit-local --name testes-rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=testes -e RABBITMQ_DEFAULT_PASS=Testes2018! rabbitmq:3-management-alpine


#3 - Clonar repositório

#4 - Configurar appsettings.json em JH.RabbitMq.Publisher e JH.RabbitMq.Consumer

#5 - Executar comando Update-Database em JH.RabbitMq.Infra.Data




