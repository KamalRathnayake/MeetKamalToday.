#START RABBIT MQ SERVICE AND CREATING THE QUEUE
docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq

#CREATING THE FUNCTION APP
func init
func new
dotnet add package Microsoft.Azure.WebJobs.Extensions.RabbitMQ
func start

#CONNECTING THE FUNCTION
https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-rabbitmq-trigger?tabs=csharp
[FunctionName("RabbitMQTriggerCSharp")]
public static void RabbitMQTrigger_BasicDeliverEventArgs(
    [RabbitMQTrigger("my-queue", HostName = "localhost")] BasicDeliverEventArgs args,
    ILogger logger
    )
{
    logger.LogInformation($"C# RabbitMQ queue trigger function processed message: {System.Text.Encoding.UTF8.GetString(args.Body)}");
}

//HOW IT WORKS DEMO