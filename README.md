# Overview

This repository contains a sample .NET Core Web API project written in C Sharp. This repo contains a solution file with a single project. The project is a simple web API that returns a "Hello World" message. A few other APIs are also included purely for demonstration purposes.

This project is intended to be run as a Docker container in Kubernetes environment. A [Dockerfile](./Dockerfile) is provided to build the image. The image is based on the official .NET Core SDK image. The project is built and published in the Dockerfile itself.

We intend to build the docker image as an environment agnostic artifact. Meaning the docker image itself will not contain any environment specific configurations. The environment specific configurations will be provided as a volume mount to the container at runtime. We would maintain a separate repository for the environment specific configurations `sample-dotnetcore-app-properties`.

# Local Development

## Docker Build and Run

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

The base location of the `appsettings.json` is configured as `/app/properties` in the `Program.cs`. The `docker build` process copies this file from the root of this repo to the path `/app/properties` inside the container. This can be overridden by pipelines
or by attaching a volume to the docker container at runtime.

## Swagger

Swagger path is http://localhost:8000/swagger/index.html
Swagger json path is http://localhost:8000/swagger/v1/swagger.json

# Pipelines

We intend to use Azure DevOps for CI/CD pipelines. The pipeline will build the docker image and push it to the Azure Container Registry. The pipeline will also deploy the image to the Kubernetes cluster. Sample pipelines are provided in the [pipelines](./pipelines/) directory. The pipelines are incomplete at this point.

The CI pipeline is designed to be triggerred on every PR Create/Update event in the topic branches. They would perform tasks like linting, unit testing, code coverage, static analysis, Docker build verification etc.

The CD pipeline is designed to be triggerred on every PR Merge event in the main branch. They would perform tasks like Docker build, tag the image, push to ACR, tag the Git repository and then deploy the application to the Kubernetes cluster in each of the defined environments in that sequence. The prospective environments are:
- Dev
- Test
- UAT
- Prod

# Helm Charts
We would use Helm charts to deploy to the Kubernetes cluster. More information about this will be provided at a later point