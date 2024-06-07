#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SaudeBemEstaApp.Authenticate/SaudeBemEstaApp.Authenticate.csproj", "SaudeBemEstaApp.Authenticate/"]
COPY ["SaudeBemEstaApp.Domain/SaudeBemEstaApp.Domain.csproj", "SaudeBemEstaApp.Domain/"]
COPY ["SaudeBemEstaApp.Infrastructure/SaudeBemEstaApp.Infrastructure.csproj", "SaudeBemEstaApp.Infrastructure/"]
RUN dotnet restore "SaudeBemEstaApp.Authenticate/SaudeBemEstaApp.Authenticate.csproj"
COPY . .
WORKDIR "/src/SaudeBemEstaApp.Authenticate"
RUN dotnet build "SaudeBemEstaApp.Authenticate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaudeBemEstaApp.Authenticate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaudeBemEstaApp.Authenticate.dll"]