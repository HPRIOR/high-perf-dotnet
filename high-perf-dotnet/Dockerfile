FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["high-perf-dotnet/high-perf-dotnet.csproj", "high-perf-dotnet/"]
RUN dotnet restore "high-perf-dotnet/high-perf-dotnet.csproj"
COPY . .
WORKDIR "/src/high-perf-dotnet"
RUN dotnet build "high-perf-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "high-perf-dotnet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "high-perf-dotnet.dll"]
