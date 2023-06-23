#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["jwt-generator/src/JWT.Generator.API/JWT.Generator.API.csproj", "jwt-generator/src/JWT.Generator.API/"]
RUN dotnet restore "jwt-generator/src/JWT.Generator.API/JWT.Generator.API.csproj"
COPY . .
WORKDIR "/src/jwt-generator/src/JWT.Generator.API"
RUN dotnet build "JWT.Generator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JWT.Generator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JWT.Generator.API.dll"]