FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SaudeBemEstaApp.Infrastructure/SaudeBemEstaApp.Infrastructure.csproj", "SaudeBemEstaApp.Infrastructure/"]
RUN dotnet restore "SaudeBemEstaApp.Infrastructure/SaudeBemEstaApp.Infrastructure.csproj"
COPY . .
WORKDIR "/src/SaudeBemEstaApp.Infrastructure"
RUN dotnet build "SaudeBemEstaApp.Infrastructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaudeBemEstaApp.Infrastructure.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaudeBemEstaApp.Infrastructure.dll"]
