public class MyAPI
{
    internal static void JoinApp(WebApplication app)
    {
        app.MapGet("/", () => "Welcome Root!");

        //app.MapGet("/courses", () => new List<object>()
        //{
        //    new {Id=1, Name="Kamal" },
        //    new {Id=2, Name="John" },
        //    new {Id=3, Name="Ann" },
        //    new {Id=4, Name="Mary" },
        //});

    }
}