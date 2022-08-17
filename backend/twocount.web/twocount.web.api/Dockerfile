FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["twocount.web.api/twocount.web.api.csproj", "twocount.web.api/"]
RUN dotnet restore "twocount.web.api/twocount.web.api.csproj"
COPY . .
WORKDIR "/src/twocount.web.api"
RUN dotnet build "twocount.web.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "twocount.web.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "twocount.web.api.dll"]
