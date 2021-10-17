dotnet new webapp --framework net5.0

docker build -t aspsample .
docker run -p 80:5000 aspsample