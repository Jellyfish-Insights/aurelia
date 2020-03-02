# Introduction

It's possible to run Aurelia manually following the steps below.

You can also run Aurelia via docker container, it's faster(and easier), the instructions can be seen [here](../run_on_docker.md).

## Building Andromeda

In order to check how [Andromeda(Aurelia's backend)](https://github.com/Jellyfish-Insights/andromeda) work you can check the instructions [here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/how_to_setup.md)

To set andromeda as git submodule inside aurelia folder run:

 `git submodule update --init --recursive`

Aurelia uses Andromeda as git submodule.
This is because Aurelia needs some of the files included on the Andromeda repository to be compiled.
To know more about how git submodule see this [link](https://git-scm.com/book/en/v2/Git-Tools-Submodules)

## Building and Running

Aurelia is composed of the following subsystems:
  - Andromeda(backend);
  - Web App.

### System Requirements

Tip: The installation of a few of Aurelia's prerequisites are covered on our medium article [here](https://medium.com/@insightsjellyfish/andromeda-storing-your-social-media-data-in-one-place-b91a6ab3d022).

Obs: The medium article is focused on [Andromeda(Aurelia's backend)](https://github.com/Jellyfish-Insights/andromeda).

You need:
  - [.NET Core SDK 2.1.X](https://dotnet.microsoft.com/download/dotnet-core/2.1)
  - [PostgreSQL 10](https://www.postgresql.org/)
  - [Docker](#Running-with-Docker)
  - [Docker-compose](#Running-with-Docker)
  - [node v9.11.1](https://nodejs.org/dist/v9.11.1/docs/api/);
  - [npm 5.6.0](https://www.npmjs.com/package/npm/v/5.6.0).

obs: If you already have another version of node and npm we recommend take a look on the [n package](https://github.com/tj/n) or use the whole systems as a docker container as presented [here](../run_on_docker.md).

### System Bootstrap

You'll need to setup a few things:
  - Install front-end dependencies;
  - Create initial migration;
  - Place the credential files.

### Note for Windows

You need to install [Git for Windows](https://git-scm.com/download/win). All of the commands in this
manual need to run over "Git Bash", not over "cmd.exe" or "powershell".
You also need to run the following commands from an admin shell to be able
to install the npm dependencies.
``` shell
  npm install --global --production windows-build-tools
  npm install --global node-gyp
```
This will allow you to do `npm install`.

### Install front-end dependencies

Go to:

`aurelia/src/WebApp` and,

Do:
```shell
  npm install
```

### Build back-end

Inside ./src/andromeda do:
```shell
  dotnet clean
  dotnet build
```

### Place the credential files

In order to place the credentials on the right folders the instructions can be seen
[here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/run_credentials_script.md#YouTube-Credentials)
via Python script or manually [here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/credential_folder_structure.md).

### Running with Docker

See [this](https://docs.docker.com/install/linux/docker-ce/ubuntu/) and [this](https://github.com/docker/compose/releases) for instructions on how to install Docker and
Docker-compose.

For Windows, the installation instructions are [here](https://docs.docker.com/docker-for-windows/install/). Docker for
Windows includes docker-compose.

Export the `DOCKER_USER` variable to ensure docker uses the same
user as the host. In Windows, `$USER` isn't defined, so you'll need
to substitute it by your username:
```shell
  export DOCKER_USER=$(id -u $USER)
```

### WebApp

Do:
```shell
  docker-compose -f docker-compose.real.yml up
```

This will make the web application available at https://localhost/.

### ConsoleApp

Do:
```shell
  docker-compose -f docker-compose.daemons.yml up
```

This will execute all the jobs. For more information on these jobs check
[its documentation](./src/README.org#jobs).

## Running Manually

### Setup PostgreSQL (Linux)

We'll need two database servers, so we recommend to just use the
docker container in the docker compose file:
```shell
  docker-compose -f docker-compose.daemons.yml up -d data_lake analytics_platform
```
After that you need to add an entry to `/etc/hosts` as the
following:
```shell
  127.0.0.1 data_lake
  127.0.0.1 analytics_platform
```

### Setup PostgreSQL (Windows)

Install [PostgreSQL](https://www.postgresql.org/download/windows/), and set the password of user `postgres`
to `dbpassword`.

After that you need to add an entry to
`C:\Windows\System32\Drivers\etc\hosts` as the following:
```
  127.0.0.1 data_lake
  127.0.0.1 analytics_platform
```

Finally, modify all `appsettings.json` files, removing the `Port=5433`
entry from the connection strings, and changing the user to `postgres`.

### Adding data to the development databases

Since the system is already running in production, we suggest loading
a dump of the production databases.

### Building the system

Assuming that you just did the [system bootstrap](#system-bootstrap),
you'll need to apply the migrations:

Navigate to `src/andromeda/Andromeda.ConsoleApp` and run:

```shell
  ./migrate.sh
```

### Running the system

To execute the `WebApp`, got into its directory and use the `dotnet run`
command.  When executing the `WebApp`, the web system will be available
at http://localhost:5000.

For running the jobs, you'll need to go to `src/andromeda/Andromeda.ConsoleApp` and run:
```shell
  dotnet run -- fetcher
```

### Creating a user

Make sure you set your email as the "DefaultUserEmail" in
`WebApp/appsettings.json`. Restart Web App and you'll become
an admin of the system.

To invite new users, navigate to the User Management page.

## Developing

When developing, make sure you install the git pre-commit hook. For more
details, see the `hooks/` directory.