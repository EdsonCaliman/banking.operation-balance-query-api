#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV TZ="America/Sao_Paulo"
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Operation.Balance.Query.Api/Banking.Operation.Balance.Query.Api.csproj", "Banking.Operation.Balance.Query.Api/"]
COPY ["Banking.Operation.Balance.Query.CrossCutting.Ioc/Banking.Operation.Balance.Query.CrossCutting.Ioc.csproj", "Banking.Operation.Balance.Query.CrossCutting.Ioc/"]
COPY ["Banking.Operation.Balance.Query.Infra.Data/Banking.Operation.Balance.Query.Infra.Data.csproj", "Banking.Operation.Balance.Query.Infra.Data/"]
COPY ["Banking.Operation.Balance.Query.Domain/Banking.Operation.Balance.Query.Domain.csproj", "Banking.Operation.Balance.Query.Domain/"]
RUN dotnet restore "Banking.Operation.Balance.Query.Api/Banking.Operation.Balance.Query.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Operation.Balance.Query.Api"
RUN dotnet build "Banking.Operation.Balance.Query.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Operation.Balance.Query.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Operation.Balance.Query.Api.dll"]