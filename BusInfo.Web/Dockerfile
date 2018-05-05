FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BusInfo.Web/BusInfo.Web.csproj BusInfo.Web/
COPY BusInfo/BusInfo.csproj BusInfo/
RUN dotnet restore BusInfo.Web/BusInfo.Web.csproj
COPY . .
WORKDIR /src/BusInfo.Web
RUN dotnet build BusInfo.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BusInfo.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BusInfo.Web.dll"]
