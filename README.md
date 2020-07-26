# Pokeapi

![Docker Image CI](https://github.com/SioJL13/pokeapi/workflows/Docker%20Image%20CI/badge.svg)

This sample application is an RESTful Web API built with ASP.NetCore.

# API description
  - `GET /api/pokemon?FirstPoke={PokemonName}&SecondPoke={PokemonName}` - Will return information based on the damage that the first pokemon will do to the second pokemon.
  - `POST /api/moves` - Based on the body receive will return the attack moves two pokemons have in common.

### Tech

Pokeapi uses the following tech:

* [Netcore] - .NET Core is a cross-platform version of .NET for building websites, services, and console apps.
* [Docker] - Container management

### Installation

Pokeapi requires [Netcore] v2.2+ to run.

Clone the repo and open the pokemon.sln file. When running the project you must see a Swagger page on port 5001.

### Docker
Pokeapi is very easy to install and deploy in a Docker container.

When ready, simply use the Dockerfile to build the image.

```sh
cd pokemon
docker build -t siofeles/pokeapi:latest .
```
This will create the pokeapi image and pull in the necessary dependencies.

Once done, run the Docker image and map the port to whatever you wish on your host. In this example, we simply map port 8000 of the host to port 8080 of the Docker:

```sh
docker run -d -p 8080:80 <youruser>/pokeapi:latest
```

Verify the deployment by navigating to your server address in your preferred browser.

```sh
127.0.0.1:8080/swagger
```

#### Kubernetes

WIP


### Todos

 - Write Tests

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)


   [Docker]: <https://www.docker.com/>
   [Netcore]: <https://dotnet.microsoft.com/download>
