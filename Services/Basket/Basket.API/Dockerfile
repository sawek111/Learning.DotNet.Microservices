FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Basket/Basket.API/Basket.API.csproj", "Basket/Basket.API/"]
COPY ["Basket/Basket.Contracts/Basket.Contracts.csproj", "Basket/Basket.Contracts/"]
COPY ["Basket/Basket.Core/Basket.Core.csproj", "Basket/Basket.Core/"]
COPY ["Basket/Basket.Infrastructure/Basket.Infrastructure.csproj", "Basket/Basket.Infrastructure/"]
COPY ["Core/Core.csproj", "Core/Core/"]
RUN dotnet restore "Basket/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/Basket/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]
