#======================================================================#
# This Dockerfile builds Aurelia's transformers docker image using     #
# the REMOTE repository:                                               #
# https://github.com/Jellyfish-Insights/aurelia.git                    #
#======================================================================#
FROM mcr.microsoft.com/dotnet/core/sdk:2.1-bionic AS builder

WORKDIR /app
# You can specify these in docker-compose.yml or with
# docker build --build-args "AURELIA_GIT_REF=git_branch_name" .
ARG AURELIA_GIT_URL=https://github.com/Jellyfish-Insights/aurelia.git
ARG AURELIA_GIT_REF=master

# Cloning from the remote repository and compiling the code
RUN git clone "$AURELIA_GIT_URL" && \
  cd aurelia && \
  git checkout "$AURELIA_GIT_REF" &&\
  git submodule update --init --recursive &&\
  cd src/ConsoleApp &&\
  dotnet publish -c release -o /app/release

# Multi-stage build
# Changing to the image that will run the project
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-bionic
WORKDIR /app/release
# Copying all necessary files from the Builder Image
COPY --from=builder /app/release .
COPY --from=builder /app/aurelia/src/ConsoleApp/run.sh .
RUN chmod +x run.sh
# Create directory for facebook cache
RUN mkdir cache
CMD ./run.sh