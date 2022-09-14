az ad sp create-for-rbac --name "personal-laptop-for-tf" --role="Contributor" --scopes="/subscriptions/<subscription-id>"

$Env:ARM_CLIENT_ID = "<APPID_VALUE>"
$Env:ARM_CLIENT_SECRET = "<PASSWORD_VALUE>"
$Env:ARM_SUBSCRIPTION_ID = "<SUBSCRIPTION_ID>"
$Env:ARM_TENANT_ID = "<TENANT_VALUE>"

terraform init     # initialize the repo
terraform plan     # create the execution plan
terraform apply    # apply the configuration
terraform graph    # generates a visual representation
terraform validate # validates the configuration files
terraform show     # huamn readable output from state/plan

terraform apply -var key=value # variable inputs

terraform destroy # destroy the resources

az ad sp delete --id $Env:ARM_CLIENT_ID