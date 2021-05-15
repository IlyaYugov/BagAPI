# BagAPI

Requared condition for Use Yandex API, you should use Banner
https://yandex.ru/dev/rasp/doc/reference/query-copyright.html

Doker repository 
https://hub.docker.com/repository/docker/napaum/bagapi/general

Doker image pull command 
docker pull napaum/bagapi:latest

Swagger
swagger http://localhost:5000/swagger/index.html

use request headers with Authorization header
Like that
headers: {
    "Accept": "application/json",
    "Authorization": "Bearer " + token  // передача токена в заголовке
}

some request examples
Get flights between Moscow - Saint-Petersburg
https://localhost:5000/api/direction/getFlights?from=s9600366&to=s9600216&offset=0&limit=100&date=2021-07-31

