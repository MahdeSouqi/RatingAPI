﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RatingAPI.csproj", "RatingAPI/"]
RUN dotnet restore "RatingAPI/RatingAPI.csproj"
COPY . ./RatingAPI
WORKDIR "/src/RatingAPI"
RUN dotnet build "RatingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RatingAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatingAPI.dll"]
