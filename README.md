# Radix - dotnet - scenario3

App with one container. Reading from external open API. No storage. No secrets.

## Getting Started

The base for this app was created with the command: `dotnet new webapp -o radix-example-scenario-1-dotnet`, in addition to this
we use the following open API:
* [CoinMarketCap](https://coinmarketcap.com/api/) - Information about cryptocurrencies

### Developing
#### Prerequisites

To run the app you only need to have the Docker Engine and Docker Compose installed.
```
$ docker -v
Docker version 18.03.1-ce, build 9ee9f40
$ docker-compose -v
docker-compose version 1.21.1, build 5a3f1a3
```

#### Installing
Use git clone to download:
```
git clone https://github.com/Statoil/radix-example-scenario-3-dotnet.git
cd radix-example-scenario-2-dotnet
```

#### Build and run
Use the command:
```
docker-compose up
```
This will build and run your app on port 80.

Run `docker-compose down` to cleanup the Docker state.

## Deployment

The radix platform uses `radixconfig.yaml`, **not** `docker-compose.yaml`.
For deployment please follow the getting started on the [Omnia radix wiki](https://radix-wiki.azurewebsites.net/doku.php/appdeveloper/gettingstarted).

## Built With
* [.NET](https://www.microsoft.com/net)
* [Docker](https://docs.docker.com/) - Containerizing the app

## Authors
* **Mats Davidsen**
