FROM mcr.microsoft.com/dotnet/core/sdk:2.1-bionic AS builder

WORKDIR /app

# Copying all the files in this directory to the container
COPY . .
WORKDIR /app/src

# Compiling the code
RUN cd ConsoleApp &&\
    dotnet publish -c release -o /app/release
    
# Multi-stage build   
# Changing to the image that will run the project
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-bionic
WORKDIR /app/release
# Copying all necessary files from the Builder Image
COPY --from=builder /app/release .
COPY --from=builder /app/src/ConsoleApp/run.sh .
RUN chmod +x run.sh
# Create directory for facebook cache
RUN mkdir cache
CMD ./run.sh 2> /dev/null