#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
# ENV ASPNETCORE_ENVIRONMENT=Development;

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Apw.Lab.AWSSQS.Api.csproj", "Apw.Lab.AWSSQS.Api/"]

RUN dotnet restore "Apw.Lab.AWSSQS.Api.csproj"
COPY . .
WORKDIR "/src/Apw.Lab.AWSSQS.Api"
RUN dotnet build "Apw.Lab.AWSSQS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apw.Lab.AWSSQS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apw.Lab.AWSSQS.Api.dll"]