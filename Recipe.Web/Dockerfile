FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Recipe.Web/Recipe.Web.csproj", "Recipe.Web/"]
RUN dotnet restore "Recipe.Web/Recipe.Web.csproj"
COPY . .
WORKDIR "/src/Recipe.Web"
RUN dotnet build "Recipe.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Recipe.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Recipe.Web.dll"]