#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Writer/Writer.csproj", "Writer/"]
RUN dotnet restore "Writer/Writer.csproj"
COPY . .
WORKDIR "/src/Writer"
RUN dotnet build "Writer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Writer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir /app/images
RUN chmod -R 777 /app/images
ENTRYPOINT ["dotnet", "Writer.dll"]