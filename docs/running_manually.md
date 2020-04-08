# Introduction

It's possible to run Aurelia manually following the steps below. Besides
compiling the code, you will need to have an instance of
[Andromeda](https://github.com/Jellyfish-Insights/andromeda) running. Aurelia
gets the data from Andromeda's data lake and transforms it to be displayed on the
Application Page (web page).

You can also run Aurelia via docker container the instructions can be seen
[here](../run_on_docker.md).

## System Requirements

You need:
  - [.NET Core SDK 2.1.X](https://dotnet.microsoft.com/download/dotnet-core/2.1)
  - [PostgreSQL 10](https://www.postgresql.org/)
  - [Docker](https://docs.docker.com/install/linux/docker-ce/ubuntu/)
  - [Docker-compose](https://github.com/docker/compose/releases)
  - [node v9.11.1](https://nodejs.org/dist/v9.11.1/docs/api/);
  - [npm 5.6.0](https://www.npmjs.com/package/npm/v/5.6.0).

If you already have another version of node and npm we recommend take a
look at the [n package](https://github.com/tj/n) or run Aurelia's docker container as
presented [here](../run_on_docker.md).

### Minimum requirements to run on a cloud
  - vCPU: 1
  - Mem (GiB): 2
  - Network Performance: Low to Moderate

*Note. Recommend to run on AWS instance `t2.small` or higher.*

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

### Installing Docker

See [this](https://docs.docker.com/install/linux/docker-ce/ubuntu/) and [this](https://github.com/docker/compose/releases) for instructions on how to install Docker and
Docker-compose.

For Windows, the installation instructions are [here](https://docs.docker.com/docker-for-windows/install/). Docker for
Windows includes docker-compose.

Export the `DOCKER_USER` variable to ensure the docker uses the same
user as the host. In Windows, `$USER` isn't defined, so you'll need
to substitute it by your username:

```shell
export DOCKER_USER=$(id -u $USER)
```

You can see how to run Aurelia using the docker container on [How to build and
run the Aurelia container document](../run_on_docker.md).

## System Bootstrap

You'll need to set up a few things before running Aurelia Webapp:
- [Get Andromeda running](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/how_to_setup.md)
- Install Aurelia's backend and frontend dependencies;
- [Create initial migration](#initial-migration);

## Cloning Aurelia repository

The first step to Run Aurelia is to clone the repository:

```bash
git clone https://github.com/Jellyfish-Insights/aurelia
cd aurelia
```

Now, we need to get andromeda as git submodule inside aurelia:

```bash
git submodule update --init --recursive
```

Aurelia uses Andromeda as a git submodule.
This is because Aurelia needs some of the files included on the Andromeda repository to be compiled.
To know more about how git submodule see this [link](https://git-scm.com/book/en/v2/Git-Tools-Submodules)

## Building and Running

Aurelia is composed of the following subsystems:

  - Backend: Transformers (ConsoleApp);
  - Frontend: Web App.

Therefore, we will need to compile and run each of these subsystems separately.

### Install frontend dependencies

On a terminal go to `aurelia/src/WebApp` and execute:

```shell
npm install
```

### Build back-end

Inside `aurelia/src` do:

```shell
dotnet clean
dotnet build
```

### Setup PostgreSQL (Linux)

We will need a database server to run Aurelia's webpage. We recommend to
just use the docker container in the docker-compose-aurelia.yml file.

However, before creating the database needed by Aurelia, we need to have
Andromeda's data lake running. You can see more information on how to
run the data lake database
[here](https://github.com/Jellyfish-Insights/andromeda/blob/master/docs/how_to_setup.md#setup-postgresql-database-linux).

After you have the data lake container up, run the following command on the root
of your cloned directory:

```shell
docker-compose -f docker-compose-aurelia.yml up -d analytics_platform
```

If the command ran successfully, you should see something like this on your
terminal:

```bash
Creating volume "aurelia_analytics_platform_data" with default driver
Creating analytics_platform ... done
```

After that you need to add an entry to `/etc/hosts` as the
following:

```shell
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

Finally, modify all `appsettings.json` files
(`aurelia/ConsoleApp/appsettings.json` and `aurelia/WebApp/appsettings.json`)
removing the `Port=5433` entry from the connection strings, and changing the
user to `postgres`. You can more about the `appsettings.json` files
[here](https://github.com/Jellyfish-Insights/aurelia/blob/master/run_on_docker.md#aurelia).

### Initial migration

To apply the initial migrations, on terminal navigate to
`aurelia/src/ConsoleApp` and run:

```shell
dotnet run migrate --application
```

### Running the system

Assuming that you just did the [system bootstrap](#system-bootstrap), it's time
to run the system.

Before running the web app, we will need to get the data from Andromeda's
data lake and transforming it (format) to be displayed by the Webapp. To do
this, in the terminal navigate to `aurelia/src/ConsoleApp` and run:

```shell
dotnet run transformer -s Application
```

To execute the `WebApp`, got into its directory (`aurelia/src/WebApp`) and
execute the following command:

```bash
dotnet run
```

When executing the `WebApp`, the web system will be available
at http://localhost:5000

### Creating a user

Make sure you set your email as the "DefaultUserEmail" in
`aurelia/src/WebApp/appsettings.json`. Restart Web App and you'll become
an admin of the system.

To invite new users, navigate to the User Management page.
