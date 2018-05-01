FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64761
EXPOSE 44369

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY BusInfo.Web/BusInfo.Web.csproj BusInfo.Web/
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
