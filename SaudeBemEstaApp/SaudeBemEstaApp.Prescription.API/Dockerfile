#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SaudeBemEstaApp.Prescription.API/SaudeBemEstaApp.Prescriptions.API.csproj", "SaudeBemEstaApp.Prescription.API/"]
COPY ["SaudeBemEstaApp.Domain/SaudeBemEstaApp.Domain.csproj", "SaudeBemEstaApp.Domain/"]COPY ["SaudeBemEstaApp.Infrastructure/SaudeBemEstaApp.Infrastructure.csproj", "SaudeBemEstaApp.Infrastructure/"]
RUN dotnet restore "./SaudeBemEstaApp.Prescription.API/SaudeBemEstaApp.Prescriptions.API.csproj"
COPY . .
WORKDIR "/src/SaudeBemEstaApp.Prescription.API"
RUN dotnet build "./SaudeBemEstaApp.Prescriptions.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SaudeBemEstaApp.Prescriptions.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionStrings__DefaultConnection=${DB_CONNECTION_STRING}
ENTRYPOINT ["dotnet", "SaudeBemEstaApp.Prescriptions.API.dll"]