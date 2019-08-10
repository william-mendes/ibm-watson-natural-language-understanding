FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE $PORT

ENV ASPNETCORE_URLS http://+:5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY TextAnalyserApi.sln ./
COPY textanalyser.api/textanalyser.api.csproj textanalyser.api/
COPY . .
WORKDIR /src/textanalyser.api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "textanalyser.api.dll"]