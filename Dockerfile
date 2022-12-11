# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore ./FrontendBFF --disable-parallel
RUN dotnet publish ./FrontendBFF -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
Copy --from=build /app ./

EXPOSE 5005-5006

ENTRYPOINT ["dotnet", "FrontendBFF.Api.dll"]