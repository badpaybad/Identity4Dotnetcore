FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Identity4WebClient/Identity4WebClient.csproj", "Identity4WebClient/"]
RUN dotnet restore "Identity4WebClient/Identity4WebClient.csproj"
COPY . .
WORKDIR "/src/Identity4WebClient"
RUN dotnet build "Identity4WebClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Identity4WebClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity4WebClient.dll"]