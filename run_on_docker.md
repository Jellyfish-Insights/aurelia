# Introduction

## Prerequisites

- Docker
- Docker compose

## Configuration files

In order to run Aurelia and Andromeda in the docker containers, first we need to
set up the configuration files for each project.

### Andromeda

#### Getting the credentials

The first step to run Andromeda and Aurelia is to get the credentials for each
social media that you want to pull out data from. The credential files are used
to allow Andromeda to pull your data from the Social Media APIs. You can get
more information of how to get and configure the credentials for each social
media on this link: [link]

#### Creating the folder structure

In order to run Andromeda container, we need to create a folder containing **at
least one social media credential** and the configuration file `appsettings.json`.
The file `appsettings.json` is the file that contains additional information
needed by andromeda to run, like database information and it needs to be in the
root of this directory. Each credential file needs to be in a folder with the
name of the social media that it belongs to. The following steps demonstrate how
to create the folder structure and how place correctly the the necessary files.

1. To create all the folders needed by Andromeda, open a terminal window and run
   the following command:

    ```bash
    mkdir andromeda && cd andromeda && mkdir adwords facebook instagram youtube
    ```

2. In sequence, copy the credential files from each social medias to their
   respective directories inside the `andromeda' folder. For instance, if you
   have all the credentials from the social media that Andromeda supports, your
   folder structure should be the following:

    ```bash
    andromeda
    │   appsettings.json
    │
    └───facebook
    │       addaccount_credentials.json
    │       page_credentials.json
    │
    └───youtube
    │       client_secret.json
    │       Google.Apis.Auth.OAuth2.Responses.TokenResponse-Credentials.json
    │
    └───adwords
    |       App.config
    |
    └───instagram
            instagram_credentials.json
    ```

#### Configuring the appsettings.json

The last step to configure Andromeda is to create and configure the file
`appsettings.json`. On this file, we will need to setup the data lake
information for Andromeda be able to connect with it. The information that we
need is:

- Host: The link to the data base, if you plan to run the database as
container leave this with the container name.  
- Database: Database's name.  
- Username: Database's username.  
- Password: Database's password.  
- Port: Port in which the database is listening.

All this information should be on a unique string separated by '`;`', you can see
an example below.

If you are running the database in containers, all these values should match the
values put in the `docker-compose.yml` file.

Here is an example of how to configure Andromeda to run with a postgres
container set up as the data_lake on the `docker-compose.yml` (default
configuration).

1. Create an `appsettings.json` file on the `andromeda` folder with a text
    editor. You can create and open the file with the vim editor executing the
    following command on a terminal:

    ```bash
    vim appsettings.json
    ```

2. Copy the following snippet in the newly created file:

    ```json
    {
        "ConnectionStrings": {
            "DataLakeDatabase": "Host=data_lake;Database=data_lake;Username=fee;Password=dbpassword;Port=5433"
        },
    }
    ```

3. Save and close the file.

### Aurelia

In order to run Aurelia container, we need to create a folder containing the
configuration file `appsettings.json`. In Aurelia's case, the file
`appsettings.json` is where we configure:

- Google credentials to use google sign in to login in the web page
- Database information from the data lake and analytics databases
- System administrator's email

The following steps demonstrate how to create and configure the file
`appsettings.json`.

1. Inside a folder called `aurelia` create the file `appsettings.json`.
   The following commands show how to create the `appsettings.json` on terminal
   with vim text editor:

    ```bash
    mkdir aurelia
    cd aurelia
    vim appsettings.json
    ```

2. Copy the following snippet in the `appsettings.json`

    ```json
    {
        "Logging": {
            "LogLevel": {
                "Default": "Warning"
            }
        },
        "Authentication:Google:ClientId": "<GOOGLE CLIENT ID>",
        "Authentication:Google:ClientSecret": "<GOOGLE CLIENT SECRET>",
        "ConnectionStrings": {
            "BusinessDatabase": "Host=analytics_platform;Database=analytics_platform;Username=fee;Password=dbpassword;Port=5432",
            "DataLakeDatabase": "Host=data_lake;Database=data_lake;Username=fee;Password=dbpassword;Port=5433"
        },
        "DefaultUserEmail": "<YOUR GOOGLE EMAIL HERE>"
    }
    ```

3. Replace the values in the fields `"Authentication:Google:ClientId"` and
   `"Authentication:Google:ClientSecret"` with the Google client ID and secret
   that you created for Aurelia. Also, you can use the same ID and secret that
   you created for youtube credential file `client_secret.json`. More details of
   how to get this credential can be seen here: [link]

4. If you plan to run the docker-compose with its default feature leave
   `"ConnectionStrings"` unchanged.

   On `"ConnectionStrings"` we setup the data lake and the analytics platform
   database information for Aurelia be able to connect with them.

   For each database, the information that we need is:

    - Host: The link to the data base, if you plan to run the database as
    container leave this with the container name.  
    - Database: Database's name.  
    - Username: Database's username.  
    - Password: Database's password.  
    - Port: Port in which the database is listening.

    All this information should be on a unique string separated by '`;`'.
    If you are running the database in containers, all these values should match the
    values put in the `docker-compose.yml` file.

5. Replace the value in field `"DefaultUserEmail"` with the email of the System
   administrator.
6. Save and close the file.

## Running the docker containers

Once you have the folders `andromeda` and `aurelia` with all the necessary
files, to run the containers, we just need to run the docker-compose files.

**Since Aurelia uses Andromeda as its backend, we need to run Andromeda
docker-compose file first for the whole system to work.**

### Getting Andromeda docker-compose file

To get the docker-compose file for Andromeda, run the following command on the
terminal:

```bash
curl -o docker-andromeda.yml https://raw.githubusercontent.com/Jellyfish-Insights/andromeda/master/docker-compose.yml
```

### Optional: Editing the docker-andromeda.yml

**If you want to run Andromeda with its default features and have the folder `andromeda`
on the same directory than the `docker-andromeda.yml` file you can skip this section.**

By default the Andromeda container will search for a folder called `andromeda` on
the directory where the docker-andromeda.yml is located. You can change this by
editing the `docker-andromeda.yml` file. The following steps show how to edit
this file using the terminal and the vim text editor.

1. Open the docker-andromeda.yml file with vim:

    ```bash
    vim docker-andromeda.yml
    ```

2. Locate the line under the Andromeda service:

    ```yml
    - ./andromeda:/app/release/credentials
    ```

3. Change the path on the left side of '`:`' to the path to your `andromeda` folder
which you have all the credentials and the file `appsettings.json`.

4. [OPTIONAL][Changing Fetcher time] Locate the line under the Andromeda service:

    ```yml
    - FETCH_SLEEP_TIME=120 #seconds
    ```

   Andromeda's fetchers fetches the social media data every "X" seconds. This
   variable controls how much time the fetchers will wait to run again.

5. Close and save the file.

**You can edit the docker-compose.yml as you need, this file has descriptions for
all important fields necessary to run the application. If you change the
database information (recommended on production) don't forget to update the
`appsettings.json` with the corresponding changes.**

### Running the Andromeda container

In order to run the database containers, we need to kill any postgres process
running on your computer. You can do this by executing the following command on
terminal:

```bash
sudo pkill -9 postgres
```

To run the Andromeda container, open a terminal window on the folder where you
downloaded `docker-andromeda.yml` file and execute the following command:

```bash
docker-compose -f docker-andromeda.yml up andromeda
```

### Getting Aurelia docker-compose file

To get the docker-compose file for Aurelia run the following command on the
terminal:

```bash
curl -o docker-aurelia.yml https://raw.githubusercontent.com/Jellyfish-Insights/aurelia/master/docker-compose.yml
```

### Optional: Editing the docker-aurelia.yml

**If you want to run Aurelia with its default features and have the folder
`aurelia` on the same directory than the `docker-aurelia.yml` file you can skip
this section.**

By editing the `docker-aurelia.yml` file you can modify the behavior of your
Aurelia container, like the port used by the web page, `aurelia` folders path,
transformers time and database information.

The following steps show how to edit `aurelia` folders path using the terminal
and the vim text editor.

1. Open the docker-aurelia.yml file with vim:

    ```bash
    vim docker-aurelia.yml
    ```

2. Locate all occurrences of the line:

    ```yml
    - ./aurelia:/app/release/config
    ```

    This configuration appears on the Transformer and Aurelia services.

3. Change the path on the left side of '`:`' to the path to your `aurelia` folder
which you have the file `appsettings.json`.

4. [OPTIONAL][Changing Web Page port] You can change the port where the Web Page
   will be exposed on your host system. To do this, locate and change the
   following line under the Aurelia service to the port number that you wish to
   expose Aurelia's web page:

    ```yml
     ports:
      # Ports exposed to the host system. You can access the website
      # on your host using this port.
      - 5000:5000
    ```

5. [OPTIONAL][Changing Transformers time] Locate the line under the Transformers service:

    ```yml
    - TRANSFORMATION_SLEEP_TIME=120 #seconds
    ```

   Aurelia's transformers run the transformation from the data lake data every
   "X" seconds. This variable controls how much time the transformers will wait to
   run again.

6. Close and save the file.

**You can edit the docker-aurelia.yml as you need, this file has descriptions for
all important fields necessary to run the application. If you change the
database information (recommended on production) don't forget to update the
`appsettings.json` with the corresponding changes.**

### Running Aurelia container

After you have Andromeda container running, to run the Aurelia container, open a
terminal window on the folder where you downloaded `docker-aurelia.yml` file
and execute the following command:

```bash
docker-compose -f docker-aurelia.yml up aurelia
```

# Developing

* git clone https://github.com/Jellyfish-Insights/aurelia
* cd aurelia

Bring andromeda
* git submodule update --init --recursive

* cd src/andromeda

  Edit docker-compose.yml to point to the configuration folder. Change to
  local.Dockerfile or change the branch and git directory, maybe dotnet clean,
  explain git submodule, how to update, how to docker compose file are placed
  and where to edit them!

FAQ: sudo pkill -9 postgres

* docker-compose -f docker-compose.yml up --build --force-recreate andromeda

--build --force-recreate flags forces docker-compose to rebuild your image if
--build: build images before starting containers.

--force-recreate: Recreate containers even if their configuration and image
haven't changed.

--build is a straightforward and it will create the docker images before
starting the containers. The --force-recreate flag will stop the currently
running containers forcefully and spin up all the containers again even if you
do not have changed anything into it's configuration. So, if there are any
changes, those will be picked-up into the newly created containers while
preserving the state of volumes.

* open another terminal, cd aurelia
Edit the docker-compose.yml with to point to the configuration folder

docker-compose -f docker-compose.yml up --build --force-recreate andromeda
