FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet test **/*.IntegrationTests.csproj  -l:trx;LogFileName=TestOutput.xml

RUN dotnet publish Demo.Api/Demo.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# ENTRYPOINT ["ls"]
ENTRYPOINT ["dotnet", "Demo.Api.dll"]