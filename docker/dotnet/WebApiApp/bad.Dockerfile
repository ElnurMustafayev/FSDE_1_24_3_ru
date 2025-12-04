FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /build
COPY . .
RUN dotnet publish -c Release -o dist
ENTRYPOINT [ "dotnet", "dist/WebApiApp.dll" ]