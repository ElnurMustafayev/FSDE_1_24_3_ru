FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /build
COPY . .
RUN dotnet publish -c Release -o dist

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS app
WORKDIR /app
COPY --from=build /build/dist .
ENTRYPOINT [ "dotnet", "WebApi2App.dll" ]