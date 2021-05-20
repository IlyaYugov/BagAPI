# BagAPI

To run server - execute following commands:

- docker pull napaum/bagapi
OR
- docker build -t bagapi .

- docker network create bag-network

- docker run -it --rm -p 5050:80 --network bag-network --name bagapi_container napaum/bagapi

- docker run -it --name posgresServer --network bag-network -e POSTGRES_PASSWORD=postgres -d postgres


Docker hub 
https://hub.docker.com/repository/docker/napaum/bagapi/general


Required condition for Use Yandex API, you should use Banner
https://yandex.ru/dev/rasp/doc/reference/query-copyright.html


Swagger
http://localhost:5000/swagger/index.html


Use request headers with Authorization header:
(you should get token from POST /api/Account/Token)

headers: {
    "Accept": "application/json",
    "Authorization": "Bearer " + token 
}



Request example:
Get flights from Moscow to Saint-Petersburg on date 31.07.2021
http://localhost:5000/api/direction/getFlights?from=s9600366&to=s9600216&offset=0&limit=100&date=2021-07-31


P.S. first request should be slow, because DB will be initialize by sending request to Yandex.API
