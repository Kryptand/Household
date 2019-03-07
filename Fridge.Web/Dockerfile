FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Fridge.Web/Fridge.Web.csproj", "Fridge.Web/"]
RUN dotnet restore "Fridge.Web/Fridge.Web.csproj"
COPY . .
WORKDIR "/src/Fridge.Web"
RUN dotnet build "Fridge.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Fridge.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fridge.Web.dll"]