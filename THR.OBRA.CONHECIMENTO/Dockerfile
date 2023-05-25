#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["THR.OBRA.CONHECIMENTO/THR.OBRA.CONHECIMENTO.csproj", "THR.OBRA.CONHECIMENTO/"]
RUN dotnet restore "THR.OBRA.CONHECIMENTO/THR.OBRA.CONHECIMENTO.csproj"
COPY . .
WORKDIR "/src/THR.OBRA.CONHECIMENTO"
RUN dotnet build "THR.OBRA.CONHECIMENTO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "THR.OBRA.CONHECIMENTO.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "THR.OBRA.CONHECIMENTO.dll"]