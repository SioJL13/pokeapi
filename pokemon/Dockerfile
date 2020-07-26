FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app

ARG env
ARG build_number
ARG commit

ENV BUILD=$build_number
ENV SOURCE_VERSION=$commit
ENV ASPNETCORE_ENVIRONMENT=$env

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "pokemon.dll"]