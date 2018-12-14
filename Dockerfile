FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Netcore.BackgroundTask/Netcore.BackgroundTask.csproj", "Netcore.BackgroundTask/"]
COPY ["Netcore.BackgroundTask.Core/Netcore.BackgroundTask.Core.csproj", "Netcore.BackgroundTask.Core/"]
COPY ["Netcore.BackgroundTask.Infrastructure/Netcore.BackgroundTask.Infrastructure.csproj", "Netcore.BackgroundTask.Infrastructure/"]
RUN dotnet restore "Netcore.BackgroundTask/Netcore.BackgroundTask.csproj"
COPY . .
WORKDIR "/src/Netcore.BackgroundTask"
RUN dotnet build "Netcore.BackgroundTask.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Netcore.BackgroundTask.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Netcore.BackgroundTask.dll"]