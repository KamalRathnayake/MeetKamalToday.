$grp = "cnrg"
$image = "nginx:latest"
$app = "my-countries-app"
$loc = "eastus"
$environment = "cne"

az group create --name $grp `
                --location $loc `
                

az containerapp env create --name $environment `
                           --resource-group $grp `
                           --internal-only false `
                           --location $loc

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80

$image = "kamalrathnayake/sampleappmvcapp"
$grp = "cnrg"
$app = "my-sample-todo-app"
$environment = "cne"

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80 `
  --registry-server docker.com --registry-username kamalrathnayake --registry-password 12414kdocker


$image = "kamalrathnayake/sampleappapi"
$grp = "cnrg"
$app = "my-sample-api"
$environment = "cne"

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80





  










  

$image = "kamalrathnayake/sampleappapi"
$grp = "cnrg"
$app = "my-sample-api"
$environment = "cne"

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80



$image = "kamalrathnayake/sampleappmvcapp"
$grp = "cnrg"
$app = "my-sample-todo-app"
$environment = "cne"

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80