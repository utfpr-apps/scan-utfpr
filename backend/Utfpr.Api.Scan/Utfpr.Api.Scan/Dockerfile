FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Utfpr.Api.Scan/Utfpr.Api.Scan.csproj", "Utfpr.Api.Scan/"]
RUN dotnet restore "Utfpr.Api.Scan/Utfpr.Api.Scan.csproj"
COPY . .
WORKDIR "/src/Utfpr.Api.Scan"
RUN dotnet build "Utfpr.Api.Scan.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Utfpr.Api.Scan.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Utfpr.Api.Scan.dll"]
