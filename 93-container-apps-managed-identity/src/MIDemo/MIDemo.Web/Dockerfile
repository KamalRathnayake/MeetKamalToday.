#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MIDemo.Web/MIDemo.Web.csproj", "MIDemo.Web/"]
RUN dotnet restore "MIDemo.Web/MIDemo.Web.csproj"
COPY . .
WORKDIR "/src/MIDemo.Web"
RUN dotnet build "MIDemo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MIDemo.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MIDemo.Web.dll"]