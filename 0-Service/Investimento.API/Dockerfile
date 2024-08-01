#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["0-Service/Investimento.API/Investimento.Api.csproj", "0-Service/Investimento.API/"]
COPY ["1-Application/Investimento.Application/Investimento.Application.csproj", "1-Application/Investimento.Application/"]
COPY ["2-Domain/Investimento.Domain/Investimento.Domain.csproj", "2-Domain/Investimento.Domain/"]
COPY ["3-Infra/Investimento.Infra/Investimento.Infra.csproj", "3-Infra/Investimento.Infra/"]
COPY ["3-Infra/Investimento.Infra.CrossCutting/Investimento.Infra.CrossCutting.csproj", "3-Infra/Investimento.Infra.CrossCutting/"]
RUN dotnet restore "./0-Service/Investimento.API/Investimento.Api.csproj"
COPY . .
WORKDIR "/src/0-Service/Investimento.API"
RUN dotnet build "./Investimento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Investimento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Investimento.Api.dll"]