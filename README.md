
# rabbitmq

.Net Core, RabbitMQ in Docker
#### JH.RabbitMq.Publisher  
Cosulta dados da API de previsão de tempo Advisor (https://advisor.climatempo.com.br/), publica o mensagem com o resultado pelo RabbitMQ.
#### JH.RabbitMq.Consumer
Recebe a mensagem publicada pelo JH.RabbitMq.Publisher, trata os dados e persiste em uma base de dados SQL Server.

### Instalação
#1 - Instalar Docker - https://www.docker.com/docker-windows

#2 - Executar comando para criar container RabbitMQ no docker
     
     docker run -d --hostname rabbit-local --name teste-rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=usuario -e RABBITMQ_DEFAULT_PASS=Senha2018! rabbitmq:3-management-alpine


#3 - Clonar repositório

#4 - Configurar appsettings.json em JH.RabbitMq.Publisher, JH.RabbitMq.Consumer e JH.RabbitMq.Infra.Data

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\sqlexpress;Database=rabbitMqDb;MultipleActiveResultSets=true;User Id=sa;Password=123456"
  },

  "RabbitMqConfigurations": {
    "HostName": "localhost",
    "Port": "5672",
    "UserName": "usuario",
    "Password": "Senha2018!"
  },

  "ApiTokenConfiguration": {
    "Token": "dabb7d369ad027c3c4e728e6c75cf6a4",
    "Locale": "3477"
  }
}
```
#5 - Executar comando Update-Database em JH.RabbitMq.Infra.Data

#6 - Configurar #Multiple Startup Projects para os projetos JH.RabbitMq.Publisher e JH.RabbitMq.Consumer
     
#7 - Executar




