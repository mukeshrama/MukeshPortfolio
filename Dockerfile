# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["MukeshPortfolio/MukeshPortfolio.csproj", "MukeshPortfolio/"]
RUN dotnet restore "MukeshPortfolio/MukeshPortfolio.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/MukeshPortfolio"
RUN dotnet build "MukeshPortfolio.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "MukeshPortfolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MukeshPortfolio.dll"]
