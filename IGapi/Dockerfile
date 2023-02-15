FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IGapi.csproj", "."]
RUN dotnet restore "IGapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "IGapi.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "IGapi.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["./https","."]
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=password
ENTRYPOINT ["dotnet", "IGapi.dll"]