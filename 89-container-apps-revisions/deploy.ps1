$grp = "ContainerRevisionsDemo"
$loc = "eastus"
$environment = "cne-rev"

# creating resource group
az group create --name $grp `
                --location $loc

# creating environment
az containerapp env create --name $environment `
                           --resource-group $grp `
                           --internal-only false `
                           --location $loc

# # rebuild images
# docker build -t kamalrathnayake/revisionsdemoapp:v1 -f 'RevisionsDemo\RevisionsDemo\WebApp\Dockerfile' 'RevisionsDemo\RevisionsDemo'
# docker push kamalrathnayake/revisionsdemoapp:v1


# creating the frontend
az containerapp create `
  --name sample-app `
  --resource-group $grp `
  --environment $environment `
  --image kamalrathnayake/webapp:v1 `
  --target-port 80 `
  --ingress 'external' `
  --min-replicas 0 `
  --max-replicas 5

   

  