FROM node:20-alpine AS frontend-build

WORKDIR /app/econsite-app

COPY econsite-app/package*.json ./
RUN npm install

COPY econsite-app/ ./

RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS backend-build

WORKDIR /app/EconSite.Api

COPY EconSite.Api/*.csproj ./
RUN dotnet restore

COPY EconSite.Api/ ./

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

COPY --from=backend-build /app/publish ./
COPY --from=frontend-build /app/econsite-app/dist ./wwwroot

EXPOSE 80

ENTRYPOINT ["dotnet", "EconSite.Api.dll"]