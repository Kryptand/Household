FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52663
EXPOSE 44327

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Ingredient.Web/Ingredient.Web.csproj Ingredient.Web/
COPY Infrastructure.Ingredient/Infrastructure.Ingredient.csproj Infrastructure.Ingredient/
COPY SharedKernel.Contracts/SharedKernel.Contracts.csproj SharedKernel.Contracts/
COPY Ingredient.Core/Ingredient.csproj Ingredient.Core/
COPY SharedKernel.Core/SharedKernel.csproj SharedKernel.Core/
RUN dotnet restore Ingredient.Web/Ingredient.Web.csproj
COPY . .
WORKDIR /src/Ingredient.Web
RUN dotnet build Ingredient.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ingredient.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ingredient.Web.dll"]
