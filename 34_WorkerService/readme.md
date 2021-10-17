

# Create Worker
dotnet new worker

# Publish
dotnet publish -o PathToThePublishFolder

# Install Package
dotnet add package Microsoft.Extensions.Hosting.WindowsServices

# Create Windows Service
sc.exe create Worker1 binpath="service.exe"

# Manage Service Lifetime
sc.exe start Worker1
sc.exe stop Worker1
sc.exe delete Worker1


        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);
        } 
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }
        public override void Dispose()
        {
        }

