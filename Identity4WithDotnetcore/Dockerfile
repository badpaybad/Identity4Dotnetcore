FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Identity4WithDotnetcore/Identity4WithDotnetcore.csproj", "Identity4WithDotnetcore/"]
RUN dotnet restore "Identity4WithDotnetcore/Identity4WithDotnetcore.csproj"
COPY . .
WORKDIR "/src/Identity4WithDotnetcore"
RUN dotnet build "Identity4WithDotnetcore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Identity4WithDotnetcore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity4WithDotnetcore.dll"]