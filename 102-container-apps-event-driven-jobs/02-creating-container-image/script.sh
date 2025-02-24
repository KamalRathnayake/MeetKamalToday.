ACR_LOGIN_SERVER="{container_registry_name}"
IMAGE_NAME="sample-app"
TAG="v1"
ACR_IMAGE="$ACR_LOGIN_SERVER/$IMAGE_NAME:$TAG"
az acr login --name $ACR_LOGIN_SERVER
az acr build --registry "${ACR_LOGIN_SERVER%%.*}" --image "$IMAGE_NAME:$TAG" .
