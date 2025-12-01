FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o dist
ENTRYPOINT [ "dotnet", "./dist/ConsoleApp.dll" ]