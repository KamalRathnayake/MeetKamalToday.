$grp='AKSDemoRG'
$loc='eastus'
$cluster='TheAKSCluster'

az group create --name $grp `
                --location $loc

az aks create --name $cluster `
              --resource-group $grp `
              --node-count 1 `
              --enable-addons monitoring `
              --generate-ssh-keys

az aks install-cli
az aks get-credentials --resource-group $grp --name $cluster


kubectl apply -f .\app.yaml
kubectl apply -f .\lb.yaml

# WEB UI - https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.5.0/aio/deploy/recommended.yaml
kubectl describe secret -n kube-system # Get token kubernetes.io/service-account-token
kubectl proxy
# ACCESS WEB UI - http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/

kubectl create deployment kubernetes-bootcamp --image=gcr.io/google-samples/kubernetes-bootcamp:v1
