FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY *.csproj .
RUN dotnet restore

COPY . . 
RUN dotnet publish --configuration release --output /dist --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /dist .
ENTRYPOINT [ "dotnet", "Fargate.Example.Api.dll" ] 