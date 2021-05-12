# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY BagAPI/*.sln .
COPY BagAPI/ShareBagAPI/*.csproj ./ShareBagAPI/

COPY BagAPI/DataAccess/*.csproj ./DataAccess/
COPY BagAPI/Domain/*.csproj ./Domain/
COPY BagAPI/YandexAPIWorker/*.csproj ./YandexAPIWorker/
COPY BagAPI/ConsoleTest/*.csproj ./ConsoleTest/

COPY BagAPI/DTO/*.csproj ./DTO/
COPY BagAPI/Tests/*.csproj ./Tests/
COPY BagAPI/YandexApiParser/*.csproj ./YandexApiParser/

RUN dotnet restore

# copy everything else and build app
COPY BagAPI/ShareBagAPI/. ./ShareBagAPI/

COPY BagAPI/DataAccess/. ./DataAccess/
COPY BagAPI/Domain/. ./Domain/
COPY BagAPI/YandexAPIWorker/. ./YandexAPIWorker/
COPY BagAPI/ConsoleTest/. ./ConsoleTest/
COPY BagAPI/DTO/. ./DTO/
COPY BagAPI/Tests/. ./Tests/
COPY BagAPI/YandexApiParser/. ./YandexApiParser/

WORKDIR /source/ShareBagAPI
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ShareBagAPI.dll"]