# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Salin file csproj (karena Dockerfile sejajar dengan csproj, kita pakai ./)
COPY ["Ticketing.API.csproj", "./"]
# Restore dependencies
RUN dotnet restore "./Ticketing.API.csproj"

# Salin seluruh file code ke dalam container
COPY . .

# Build aplikasi
RUN dotnet build "Ticketing.API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "Ticketing.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Runtime final (Image yang ringan)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

# Salin hasil publish dari stage sebelumnya
COPY --from=publish /app/publish .

# Set port default yang dikenali oleh Render
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Ticketing.API.dll"]