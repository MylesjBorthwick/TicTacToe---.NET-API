FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TicTacToe.csproj", "./"]
RUN dotnet restore "TicTacToe.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TicTacToe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTacToe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTacToe.dll"]
