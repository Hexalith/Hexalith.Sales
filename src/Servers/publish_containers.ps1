az login --tenant christofle.com
az acr login -n christofle
$version=(minver -t v -v e -d preview)
cd ./Hexalith.Server.Sales
dotnet publish /t:PublishContainer -c Release -p ContainerRegistry="christofle.azurecr.io" -p ContainerImageTag=$version
pause
