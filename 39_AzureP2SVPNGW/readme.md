```bash
# POINT TO SITE SAMPLE
$grp="P2STESTRG"
$location1="southeastasia" 
$vnetName1="SEAvnet" 
$subnetName="Subnet1"
$vmName="SEA_VM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location1

# CREATING NETWORK IN SEA
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName1 --resource-group $grp --location $location1
az network vnet subnet create -g $grp --vnet-name $vnetName1 -n $subnetName --address-prefixes 10.0.0.0/24
az vm create --resource-group $grp --name $vmName --image Win2019Datacenter --vnet-name $vnetName1 --subnet $subnetName --admin-username kamal --admin-password Hello@12345#

# GENERATE CERTIFICATES WITH POWERSHELL
# root certificate
$cert = New-SelfSignedCertificate -Type Custom -KeySpec Signature -Subject "CN=RootCertificate" -KeyExportPolicy Exportable -HashAlgorithm sha256 -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" -KeyUsageProperty Sign -KeyUsage CertSign
# client certificate
New-SelfSignedCertificate -Type Custom -DnsName P2SChildCert -KeySpec Signature -Subject "CN=ClientCertificate" -KeyExportPolicy Exportable -HashAlgorithm sha256 -KeyLength 2048 -CertStoreLocation "Cert:\CurrentUser\My" -Signer $cert -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.2")


```