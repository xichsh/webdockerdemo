#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebDockerDemo.Web/WebDockerDemo.Web.csproj", "WebDockerDemo.Web/"]
COPY ["WebDockerDemo.Model/WebDockerDemo.Model.csproj", "WebDockerDemo.Model/"]
COPY ["WebDockerDemo.Bll/WebDockerDemo.Bll.csproj", "WebDockerDemo.Bll/"]
COPY ["WebDockerDemo.Dal/WebDockerDemo.Dal.csproj", "WebDockerDemo.Dal/"]
RUN dotnet restore "WebDockerDemo.Web/WebDockerDemo.Web.csproj"
COPY . .
WORKDIR "/src/WebDockerDemo.Web"
RUN dotnet build "WebDockerDemo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebDockerDemo.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebDockerDemo.Web.dll"]