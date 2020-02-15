#======================================================================#
# This Dockerfile builds Aurelia's web app docker image using          #
# your LOCAL copy of aurelia's directory. This image is useful when    #
# developing changing in the code.                                     #
#======================================================================#
FROM mcr.microsoft.com/dotnet/core/sdk:2.1-bionic AS builder

WORKDIR /app

# Installing node 9
RUN apt update && \
  apt install -y wget &&\
  apt install -y nodejs &&\
  apt install -y npm && \
  npm install -g n && \
  n 9

# Copying all the files from the local root directory to the container
COPY . .
WORKDIR /app/src

# Compiling the code
RUN git submodule update --init --recursive &&\
  cd ConsoleApp &&\
  dotnet publish -c release -o /app/release &&\
  cd ../WebApp &&\
  dotnet publish -c release -o /app/release

# Multi-stage build
# Changing to the image that will run the project
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-bionic
WORKDIR /app/release
# Copying all necessary files from the Builder Image
COPY --from=builder /app/release .
COPY --from=builder /app/src/WebApp/run.sh .
RUN chmod +x run.sh
# Create directory for facebook cache
RUN mkdir cache
CMD ./run.sh 2> /dev/null