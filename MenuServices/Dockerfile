#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MenuServices/MenuServices.csproj", "MenuServices/"]
RUN dotnet restore "MenuServices/MenuServices.csproj"
COPY . .
WORKDIR "/src/MenuServices"
RUN dotnet build "MenuServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MenuServices.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MenuServices.dll"]