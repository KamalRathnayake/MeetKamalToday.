# pushing the images
docker build -t kamalrathnayake/hpdemoapp:v2 -f 'src\ContainerApps\HPDemoApp\Dockerfile' 'src\ContainerApps'
docker push kamalrathnayake/hpdemoapp:v2

$grp = "ContainerProbesDemoRG"
$loc = "eastus"

# creating resource group
az group create --name $grp `
                --location $loc

# deploy the template
az deployment group create --resource-group $grp `
                           --template-file 'template.json'