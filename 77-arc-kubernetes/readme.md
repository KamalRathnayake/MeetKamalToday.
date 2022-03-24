### KUBERNETES SAMPLE CONTAINER
```
kubectl run countries-app --image=kamalrathnayake/countriesapp
kubectl port-forward countries-app 8080:80

kubectl run courses-app --image=nginx
kubectl port-forward courses-app 8080:80
```

### ADDING PROVIDERS
```
az extension add --name connectedk8s
az extension add --name k8s-extension
az extension add --name customlocation

az provider register --namespace Microsoft.KubernetesConfiguration
az provider show -n Microsoft.KubernetesConfiguration --query "registrationState"
```

### RUN AZURE SCRIPT

### TOKEN AUTHENTICATION TO AZURE
```
kubectl create serviceaccount admin-user
kubectl create clusterrolebinding admin-user-binding --clusterrole cluster-admin --serviceaccount default:admin-user

$SECRET_NAME=kubectl get serviceaccount admin-user -o jsonpath='{$.secrets[0].name}'
$BASE64=kubectl get secret $SECRET_NAME -o jsonpath='{$.data.token}'

[Text.Encoding]::Utf8.GetString([Convert]::FromBase64String($BASE64))

 <!-- | base64 -d | sed $'s/$/\\\n/g') -->
 ```