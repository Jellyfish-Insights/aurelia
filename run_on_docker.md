# Introduction

This documentation shows how to configure and run Andromeda and Aurelia
containers.

All The the steps on this document were tested on ubuntu 18. If you plan to run this tutorial on a Windows machine, you will need to adapt
the steps that use terminal commands.

## Prerequisites

- Docker
- Docker compose

[Instructions of how to install
Docker on ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/)

[Instructions of how to install Docker Compose on ubuntu](https://github.com/docker/compose/releases)

## Configuration files

In order to run Aurelia and Andromeda in the docker containers, first, we need to
set up the configuration files for each project.

### Andromeda

#### Getting the credentials

The first step to run Andromeda and Aurelia is to get the credentials for each
social media that you want to pull out data from. The credential files are used
to allow Andromeda to pull your data from the Social Media APIs. You can get
more information about how to get and configure the credentials for each social
media on this [link](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/how_to_get_credentials.md).

#### Creating the folder structure

In order to run the Andromeda container, we need to create a folder containing at least one social media credential and the configuration file `appsettings.json` . The file `appsettings.json` is the file that contains additional information needed by andromeda to run, like database information and it needs to be in the root of the created directory. Each credential file needs to be in a folder with the name of the social media that it belongs to. The following steps demonstrate how to create the folder structure and how to place correctly the necessary files.
To create all the folders needed by Andromeda, open a terminal window and run the following command:

``` bash
mkdir andromeda-config && cd andromeda-config && mkdir adwords facebook facebook/adaccount facebook/page instagram youtube && cd ..
```

In sequence, copy the credential files from each social media to their respective directories inside the `andromeda-config` folder. For instance, if you have all the credentials from the social media that Andromeda supports and you are not using multi-accounts, your folder structure should be the following:

```
andromeda-config
│ appsettings.json
│
└─facebook
| |  user_credentials.json
| |
│ └──adaccount
| |    user1-adaccount_credentials.json
│ └──page
│      user1-page_credentials.json
|
└─youtube
│ |  client_secret.json
| |
| └──channel1_name
│      Google.Apis.Auth.OAuth2.Responses.TokenResponse-Credentials.json
│
└─adwords
|   App.config
|
└─instagram
    user1-instagram_credentials.json
```

With Andromeda you can pull data from multiple facebook, instagram and YouTube
channels and store in the same data lake. You can see more details about how to
set up multiple accounts [here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/adding_multiple_accounts.md).

#### Configuring the appsettings.json

The last step to configure Andromeda is to create and configure the file
`appsettings.json`. On this file, we will need to set up the data lake
information for Andromeda to be able to connect with it. The information that we
need is:

- Host: The link to the database, if you plan to run the database as
a container leave this with the container name.
- Database: Database's name.
- Username: Database's username.
- Password: Database's password.
- Port: Port in which the database is listening.

All this information should be on a unique string separated by semicolon (`;`),
you can see an example below.

If you are running the database in containers, all these values should match the
values put in the `docker-compose.yml` files.

Here is an example of how to configure Andromeda to run with a postgres
container set up as the data_lake on the `docker-compose-andromeda.yml` (default
configuration).

1. Create an `appsettings.json` file on the `andromeda-config` folder with a text
   editor of your preference. To illustrate the process, we will be using
   vim. You can create and open the file with the vim editor executing the
   following command on a terminal:

    ```bash
    vim appsettings.json
    ```

2. Copy the following snippet in the newly created file:

    ```json
    {
        "ConnectionStrings": {
            "DataLakeDatabase": "Host=data_lake;Database=data_lake;Username=fee;Password=dbpassword;Port=5433"
        }
    }
    ```

3. Save and close the file.

### Aurelia

In order to run the Aurelia container, we need to create a folder containing the
configuration file `appsettings.json`. In Aurelia's case, the file
`appsettings.json` is where we configure:

- Google credentials to use google sign in to log in on the web page
- Database information from the data lake and analytics databases
- System administrator's email

The following steps demonstrate how to create and configure the file
`appsettings.json`.

1. Inside a folder called `aurelia-config` create the file `appsettings.json`.
   The following commands show how to create the `appsettings.json` using the terminal
   with vim text editor:

    ```bash
    mkdir aurelia-config
    cd aurelia-config
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
   how to get this credential can be seen [here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/how_to_get_credentials.md).

4. If you plan to run the docker-compose with its default feature leave
   `"ConnectionStrings"` unchanged.

   On `"ConnectionStrings"`, we set up the data lake and the analytics platform
   database information for Aurelia to be able to connect with them.

   For each database, the information that we need is:

    - Host: The link to the database, if you plan to run the database as
    container leave this with the container name.
    - Database: Database's name.
    - Username: Database's username.
    - Password: Database's password.
    - Port: Port in which the database is listening.

   All this information should be on a unique string separated by semicolon
   (`;`).
   If you are running the database in containers, all these values should match the
   values put in the `docker-compose.yml` files.

5. Replace the value in the field `"DefaultUserEmail"` with the email of the System
   administrator.
6. Save and close the file.

## Running the docker containers

Once you have the folders `andromeda-config` and `aurelia-config` with all the necessary
files, to run the containers, we need to clone and set up Aurelia repository.

**Since Aurelia uses Andromeda as its backend, we need to run Andromeda
docker-compose file first for the whole system to work.**

### Cloning the repository

The following steps demonstrate how to clone and set up the Aurelia repository.

1. The first step is to clone the repository:

    ```bash
    git clone https://github.com/Jellyfish-Insights/aurelia
    cd aurelia
    ```

2. After you cloned the Aurelia repository, you need to run the following
   command to fetch the Andromeda repository.

    ```bash
    git submodule update --init --recursive
    ```

   Aurelia uses Andromeda as git submodule. This is because Aurelia needs some
   of the files included on the Andromeda repository to be compiled. To know more
   about how git submodule see this [link](https://git-scm.com/book/en/v2/Git-Tools-Submodules)

#### Editing the andromeda/docker-compose-andromeda.yml

By default, the Andromeda container will search for a folder called `andromeda-config`
with the credentials and the `appsettings.json` on the directory where the
`docker-compose-andromeda.yml` is located. We don't recommend to put the folder with the
credentials inside the git repository folder.

You can change the path of the  `andromeda-config` folder by editing the
`docker-compose-andromeda.yml` file. The following steps show how to edit this file using
the terminal and the vim text editor.

1. Inside the aurelia directory navigate to the andromeda folder.

    ```bash
    cd ./src/andromeda
    ```

2. Open the docker-compose-andromeda.yml file with vim:

    ```bash
    vim docker-compose-andromeda.yml
    ```

3. Locate the line under the Andromeda service:

    ```yml
    - ./andromeda-config:/app/release/credentials
    ```

4. Change the path on the left side of '`:`' to the path to your `andromeda` folder
which you have all the credentials and the file `appsettings.json`.

5. [OPTIONAL][Changing Fetcher time] Locate the line under the Andromeda service:

    ```yml
    - FETCH_SLEEP_TIME=120 #seconds
    ```

   Andromeda's fetchers fetch the social media data every "X" seconds. This
   variable controls how much time the fetchers will wait to run again.

6. Close and save the file.

**You can edit the `docker-compose-andromeda.yml` as you need it, this file has descriptions for
all important fields necessary to run the application. If you change the
database information (recommended on production) don't forget to update the
`appsettings.json` with the corresponding changes.**

#### Editing the aurelia/docker-compose-aurelia.yml

By editing the `docker-compose-aurelia.yml` file you can modify the behavior of your
Aurelia container, like the port used by the web page, `aurelia-config` folders path,
transformers' sleep time and database information.

The following steps show how to edit the path to the configuration folder
`aurelia-config` using the terminal and the vim text editor.

1. Open a terminal window on the directory where you cloned Aurelia's
   repository. Open the docker-compose-aurelia.yml file with vim:

    ```bash
    vim docker-compose-aurelia.yml
    ```

2. Locate all occurrences of the line:

    ```yml
    - ./aurelia-config:/app/release/config
    ```

    This configuration appears on the Transformer and Aurelia services.

3. Change the path on the left side of '`:`' to the path of your `aurelia-config` folder (the folder that you have the file `appsettings.json`).

4. [OPTIONAL][Changing Web Page port] You can change the port where the Web Page
   will be exposed to your host system. To do this, locate and change the
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

**You can edit the `docker-compose-aurelia.yml` as you need, this file has descriptions for
all important fields necessary to run the application. If you change the
database information (recommended on production) don't forget to update the
`appsettings.json` with the corresponding changes.**

### Running the containers

To run the Andromeda container, open a terminal in the aurelia directory then
navigate to the andromeda folder:

```bash
cd ./src/andromeda
```

Then execute the following command.

```bash
sudo docker-compose -f docker-compose-andromeda.yml up andromeda
```

**If you get an error running the database with the the command above, change the port used by the data_lake container on the docker-compose-andromeda.yml file and in the `andromeda-config/appsettings.json`.**

Now that you have Andromeda container running, we can run the Aurelia container.
Open a new terminal window on the root of directory where you cloned Aurelia's repository and run the following command:

```bash
sudo docker-compose -f docker-compose-aurelia.yml up aurelia
```

You can access Aurelia's Web page by running the following link on your
browser:

http://localhost:5000

The Aurelia Web page will be available before the Aurelia Transformers finish
the data transformation. Therefore, it can take some time for the data be visible
on the web page (usually the time that you set for the Transformers to run
again).

## Development tips

### Prune unused local volumes

If you are building the images multiple times to test your code, it's useful before
running the docker-compose files prune the unused local volumes. By doing
this, you will have a fresh build, starting everything from scratch. Run the
command below on a terminal window to prune unused local volumes:

```bash
sudo docker volume prune
```

### Build from a local copy of the repositories

By default, the docker-compose files will build the image from the files stored
in the remote repositories:

https://github.com/Jellyfish-Insights/andromeda
https://github.com/Jellyfish-Insights/aurelia

Therefore, to see your code changes applied to the docker container, you will
need to push the files to the corresponding directories.

You can change this by changing the Dockerfile used in the service's `build` command in each
docker-compose.yml by the local.Dockerfile version. For instance, in the aurelia
transformer service, if you want to build the image from the source files that
you have locally on your computer, comment the line `dockerfile: "./src/ConsoleApp/Dockerfile"`
and uncomment the line `#dockerfile: "./src/ConsoleApp/local.Dockerfile"`.

```yml
      #========================================================================
      # Build the image pulling the files from the remote directory:
      # https://github.com/Jellyfish-Insights/aurelia
      #========================================================================
      dockerfile: "./src/ConsoleApp/Dockerfile"

      #========================================================================
      # If you are developing Aurelia's code is useful to build the docker image
      # from your local copy of files instead of getting them from the remote
      # directory. If you want to build using your LOCAL COPY, comment the line:
      # dockerfile: "./src/WebApp/Dockerfile" above and
      # uncomment the line bellow.
      #========================================================================
      #dockerfile: "./src/ConsoleApp/local.Dockerfile"
```

### Forcing docker-compose up to rebuild

By default, docker-compose command doesn't rebuild the image, even if you change
a file in the build process. To force docker-compose to rebuild your image,
instead of the default command `docker-compose up` use the following one:

```bash
sudo docker-compose -f docker-compose-andromeda.yml up --build --force-recreate andromeda
```

Explanation:

`--build`: build images before starting containers.

`--force-recreate`: Recreate containers even if their configuration and image
haven't changed.

`--build` is straightforward and it will create the docker images before
starting the containers. The `--force-recreate` flag will stop the currently
running containers forcefully and spin up all the containers again even if you
do not have changed anything into its configuration. So, if there are any
changes, those will be picked-up into the newly created containers while
preserving the state of volumes.
