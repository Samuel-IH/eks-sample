FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SlotService/SlotService.csproj", "SlotService/"]
RUN dotnet restore "SlotService/SlotService.csproj"
COPY . .
WORKDIR "/src/SlotService"
RUN dotnet build "SlotService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SlotService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SlotService.dll"]
