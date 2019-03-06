FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Identity4SampleServerUseIdentity/Identity4SampleServerUseIdentity.csproj", "Identity4SampleServerUseIdentity/"]
RUN dotnet restore "Identity4SampleServerUseIdentity/Identity4SampleServerUseIdentity.csproj"
COPY . .
WORKDIR "/src/Identity4SampleServerUseIdentity"
RUN dotnet build "Identity4SampleServerUseIdentity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Identity4SampleServerUseIdentity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity4SampleServerUseIdentity.dll"]