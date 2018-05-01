FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58335
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY BusInfo.API/BusInfo.API.csproj BusInfo.API/
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
