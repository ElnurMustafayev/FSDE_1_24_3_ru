docker network ls
docker network
docker network create --driver bridge webapi_network

docker build -t webapi1 .
docker run -d --rm --name webapi1_app -p 8001:8080 --network webapi_network webapi1

docker build -t webapi2 .
docker run -d --rm --name webapi2_app -p 8002:8080 --network webapi_network webapi2

docker run -d -e "POSTGRES_USER=bob" -e "POSTGRES_PASSWORD=Secret12345!" -e "POSTGRES_DB=mydb" -p 5432:5432 --name postgres_db --network webapi_network postgres:latest