## Build

```bash
# build the image
docker build -t dotnet-helloworld .

# run the container
docker run -it --name=dotnet-sample \
    --rm -v /Users/a266721/Downloads/HelloWorld/pipelines:/app/properties \
    -p 8000:8000 -h hello-world.dsahoo.com \
    -e ASPNETCORE_ENVIRONMENT=Development \
    -e ASPNETCORE_URLS="http://*:8000" \
    dotnet-helloworld
```

## appsettings.json

The base location of the `appsettings.json` is configured as `/app/properties` in the `Program.cs`. This can be overridden by pipelines
or by attaching a volume to the docker run command

## Swagger

Swagger path is http://localhost:8000/swagger/index.html
Swagger json path is http://localhost:8000/swagger/v1/swagger.json