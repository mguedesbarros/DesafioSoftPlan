#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/API/CalculoJurosAPI/CalculoJurosAPI.csproj", "src/API/CalculoJurosAPI/"]
COPY ["src/Services/SoftPlanService/SoftPlanService.csproj", "src/Services/SoftPlanService/"]
RUN dotnet restore "src/API/CalculoJurosAPI/CalculoJurosAPI.csproj"
COPY . .
WORKDIR "/src/src/API/CalculoJurosAPI"
RUN dotnet build "CalculoJurosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoJurosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoJurosAPI.dll"]