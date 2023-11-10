FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ordering/Ordering.WebApi/Ordering.WebApi.csproj", "Ordering/Ordering.WebApi/"]
COPY ["Ordering/Ordering.Application/Ordering.Application.csproj", "Ordering/Ordering.Application/"]
COPY ["Ordering/Ordering.Domain/Ordering.Domain.csproj", "Ordering/Ordering.Domain/"]
COPY ["Ordering/Ordering.Presentation/Ordering.Presentation.csproj", "Ordering/Ordering.Presentation/"]
COPY ["Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Ordering/Ordering.Infrastructure/"]

RUN dotnet restore "Ordering/Ordering.WebApi/Ordering.WebApi.csproj"
COPY . .
WORKDIR "/src/Ordering/Ordering.WebApi"
RUN dotnet build "Ordering.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.WebApi.dll"]
