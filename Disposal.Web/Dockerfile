FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Disposal.Web/Disposal.Web.csproj", "Disposal.Web/"]
RUN dotnet restore "Disposal.Web/Disposal.Web.csproj"
COPY . .
WORKDIR "/src/Disposal.Web"
RUN dotnet build "Disposal.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Disposal.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Disposal.Web.dll"]