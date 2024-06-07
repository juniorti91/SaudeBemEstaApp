FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SaudeBemEstaApp.Domain/SaudeBemEstaApp.Domain.csproj", "SaudeBemEstaApp.Domain/"]
RUN dotnet restore "SaudeBemEstaApp.Domain/SaudeBemEstaApp.Domain.csproj"
COPY . .
WORKDIR "/src/SaudeBemEstaApp.Domain"
RUN dotnet build "SaudeBemEstaApp.Domain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaudeBemEstaApp.Domain.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaudeBemEstaApp.Domain.dll"]
