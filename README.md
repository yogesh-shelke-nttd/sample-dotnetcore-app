## Build

```bash
# build the image
docker build -t dotnet-helloworld .

# run the container
docker run -it --name=dotnet-sample \
    --rm -p 8000:8000 \
    -e ASPNETCORE_ENVIRONMENT=Development \
    -e ASPNETCORE_HTTP_PORTS=8000 \
    dotnet-helloworld
```

## Swagger

Swagger path is http://localhost:8000/swagger/index.html
Swagger json path is http://localhost:8000/swagger/v1/swagger.json