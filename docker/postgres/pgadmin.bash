docker run \
    -d \
    -e "PGADMIN_DEFAULT_EMAIL=user@domain.com" \
    -e "PGADMIN_DEFAULT_PASSWORD=SuperSecret" \
    -p 9000:80 \
    --name pgadmin4_app \
    --network postgres_network \
    dpage/pgadmin4