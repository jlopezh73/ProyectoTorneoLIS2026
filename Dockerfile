# ==================== ETAPA 1: Build (multi-stage) ====================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar solo los archivos de proyecto para restaurar dependencias (caché eficiente)
COPY ["Torneo2026LIS.csproj", "./"]
RUN dotnet restore "Torneo2026LIS.csproj"

# Copiar el resto del código
COPY . .
WORKDIR "/src"
RUN dotnet build "Torneo2026LIS.csproj" -c Release -o /app/build

# ==================== ETAPA 2: Publish ====================
FROM build AS publish
RUN dotnet publish "Torneo2026LIS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ==================== ETAPA 3: Runtime (imagen final ligera) ====================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Torneo2026LIS.dll"]