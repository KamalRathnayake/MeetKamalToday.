using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Mvc;

namespace WebPubSubBackend.Controllers;
[ApiController]
[Route("[controller]")]
public class PubSubController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var connectionString = "Endpoint=https://webpubsubdemo2021.webpubsub.azure.com;AccessKey=xbsecfIWtQEGgGpwvkHMoG17HhmcLEKfQKbC7CfJt1o=;Version=1.0;";
        var hubName = "first_hub";
        var serviceClient = new WebPubSubServiceClient(connectionString,
                                                       hubName);

        var uri = serviceClient.GetClientAccessUri(TimeSpan.FromHours(1));

        return Ok(new { uri = uri });
    }
}
