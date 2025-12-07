docker run \
    -d \
    -e "POSTGRES_USER=bob" \
    -e "POSTGRES_PASSWORD=Secret12345!" \
    -e "POSTGRES_DB=mydb" \
    -p 5432:5432 \
    --name postgres_db \
    postgres:latest