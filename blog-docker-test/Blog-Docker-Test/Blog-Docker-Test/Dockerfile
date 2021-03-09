#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Blog-Docker-Test/Blog-Docker-Test.csproj", "Blog-Docker-Test/"]
RUN dotnet restore "Blog-Docker-Test/Blog-Docker-Test.csproj"
COPY . .
WORKDIR "/src/Blog-Docker-Test"
RUN dotnet build "Blog-Docker-Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog-Docker-Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog-Docker-Test.dll"]