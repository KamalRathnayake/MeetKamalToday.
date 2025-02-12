RESOURCE_GROUP="rg-container-apps-jobs"
LOCATION="eastus"
ENV_NAME="cae-jobs-demo-01"
JOB_NAME="sample-job-01"
ACR_IMAGE="{cr}.azurecr.io/sample-app:v1"
ACR_LOGIN_SERVER="{cr}.azurecr.io"
ACR_NAME="{cr}"

az group create --name "$RESOURCE_GROUP" --location "$LOCATION"

az containerapp env create --name "$ENV_NAME" --resource-group "$RESOURCE_GROUP" --location "$LOCATION"


az containerapp job create \
  --name "job-01" \
  --resource-group "$RESOURCE_GROUP" \
  --environment "$ENV_NAME" \
  --trigger-type "Manual" \
  --replica-timeout 1800 \
  --replica-retry-limit 2 \
  --replica-completion-count 1 \
  --parallelism 1 \
  --cpu "0.25" \
  --registry-server "{cr}.azurecr.io"\
  --registry-username "{cr}"\
  --registry-password "{password}"\
  --memory "0.5Gi" \
  --image "{cr}.azurecr.io/sample-app:v1"

az containerapp job start -n "job-01" -g "$RESOURCE_GROUP"
az containerapp job start -n "job-01" -g "$RESOURCE_GROUP" --cpu 0.5 --memory 1.0Gi
