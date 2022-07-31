#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Reader/Reader.csproj", "Reader/"]
RUN dotnet restore "Reader/Reader.csproj"
COPY . .
WORKDIR "/src/Reader"
RUN dotnet build "Reader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reader.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir /app/images
ENTRYPOINT ["dotnet", "Reader.dll"]