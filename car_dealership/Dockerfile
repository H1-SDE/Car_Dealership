#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["car_dealership/car_dealership.csproj", "car_dealership/"]
RUN dotnet restore "car_dealership/car_dealership.csproj"
COPY . .
WORKDIR "/src/car_dealership"
RUN dotnet build "car_dealership.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "car_dealership.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "car_dealership.dll"]