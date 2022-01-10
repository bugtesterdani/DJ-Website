#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cluster_Management_Studio/Cluster_Management_Studio.csproj", "Cluster_Management_Studio/"]
RUN dotnet restore "Cluster_Management_Studio/Cluster_Management_Studio.csproj"
COPY . .
WORKDIR "/src/Cluster_Management_Studio"
RUN dotnet build "Cluster_Management_Studio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cluster_Management_Studio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cluster_Management_Studio.dll"]