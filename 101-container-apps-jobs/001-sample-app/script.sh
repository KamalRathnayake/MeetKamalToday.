ACR_LOGIN_SERVER="mkt01.azurecr.io"
IMAGE_NAME="sample-app"
TAG="v1"
ACR_IMAGE="$ACR_LOGIN_SERVER/$IMAGE_NAME:$TAG"
az acr login --name $ACR_LOGIN_SERVER
az acr build --registry "${ACR_LOGIN_SERVER%%.*}" --image "$IMAGE_NAME:$TAG" .
