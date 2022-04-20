#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Apw.Lab.AWSSQS.Consumer/Apw.Lab.AWSSQS.Consumer.csproj", "Apw.Lab.AWSSQS.Consumer/"]
RUN dotnet restore "Apw.Lab.AWSSQS.Consumer/Apw.Lab.AWSSQS.Consumer.csproj"
COPY . .
WORKDIR "/src/Apw.Lab.AWSSQS.Consumer"
RUN dotnet build "Apw.Lab.AWSSQS.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apw.Lab.AWSSQS.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apw.Lab.AWSSQS.Consumer.dll"]