#!/bin/bash

set -ex

FOLDER="config"
FILES=("appsettings.json")

all_run_files_exists () {
    if [ ! -e "$FOLDER" ]; then
        echo "$FOLDER does not exist inside this container!"
        echo "Check if you binded the correct host folder with all the necessary files on the docker-compose file!"
        # 1 = false/the process failed
        return 1
    fi
    cd $FOLDER
    for FILE in $FILES; do
        if [ ! -f "$FILE" ]; then
            echo "Could not find the file: $FILE"
            echo "Check if the binded host folder contain this file!"
            # 1 = false
            return 1
        fi
    done
    cd ..
    # 0 = true/success
    return 0
}

if all_run_files_exists; then
    echo "Copying configuration files"
    cp config/appsettings.json .

    echo "Migrating the data"
    dotnet ConsoleApp.dll migrate --application

    echo "Running the web app"
    dotnet WebApp.dll

fi