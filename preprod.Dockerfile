FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/Gosell.API"
RUN dotnet restore "Gosell.API.csproj"
# RUN dotnet build "Gosell.API.csproj" -c preprod -o /app/build
RUN dotnet publish "Gosell.API.csproj" -c preprod -o /app/publish
    
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_ENVIRONMENT=preprod
ENTRYPOINT ["dotnet", "Gosell.API.dll", "-c", "preprod"]