FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BusInfo.API/BusInfo.API.csproj BusInfo.API/
COPY BusInfo/BusInfo.csproj BusInfo/
RUN dotnet restore BusInfo.API/BusInfo.API.csproj
COPY . .
WORKDIR /src/BusInfo.API
RUN dotnet build BusInfo.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BusInfo.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BusInfo.API.dll"]
