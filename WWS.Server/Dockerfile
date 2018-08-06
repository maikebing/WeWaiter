FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52958
EXPOSE 44366

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WWS.Server/WWS.Server.csproj WWS.Server/
RUN dotnet restore WWS.Server/WWS.Server.csproj
COPY . .
WORKDIR /src/WWS.Server
RUN dotnet build WWS.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WWS.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WWS.Server.dll"]
