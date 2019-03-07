FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ChefMaster/ChefMaster.csproj", "ChefMaster/"]
RUN dotnet restore "ChefMaster/ChefMaster.csproj"
COPY . .
WORKDIR "/src/ChefMaster"
RUN dotnet build "ChefMaster.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ChefMaster.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ChefMaster.dll"]