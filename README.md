# todo-api

[![CI](https://github.com/codenthusiast/todo-api/actions/workflows/ci.yml/badge.svg)](https://github.com/codenthusiast/todo-api/actions/workflows/ci.yml)

A demo Containerized ASP.NET Core API implementing repository pattern CI with Github Actions and docker compose.

## Setup - local

 - Ensure you have docker running on your local machine.
 - Clone this repository and cd into the cloned directory
 - run `cd TodoApi`
 - Rename the `.env.sample` file to `.env`
 - Change the values of the environment variables in the `.env` file to suit your needs
 ```
 MYSQL_ROOT_PASSWORD=root
MYSQL_DATABASE=todo_db
MYSQL_USER=admin
MYSQL_PASSWORD=root
MYSQL_CONN_STRING=server=db;database=todo_db;user=admin;password=root;port=3306
```

- Run `docker-compose -up` to spin up the api and the mysql containers
- Goto http://localhost:5080 in your browser. A swagger page will be loaded to interact with the API.

## Setup - Server
Github actions
- Setup [secrets](https://docs.github.com/en/actions/security-guides/encrypted-secrets) to store sensitive environment variables.
- Follow this [guide](https://docs.github.com/en/actions/hosting-your-own-runners/adding-self-hosted-runners)  to setup a Github actions runner on your server.
- Ensure runner is running.
- From the root folder, `cd .github/workflows/`
- update the contentent of the `ci.yml` file accordingling
```yml
# This is a basic workflow to help you get started with Actions

name: CI

# Controls when the workflow will run
on:
  # Triggers the workflow on push or pull request events but only for the master branch
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]

  # Allows you to run this workflow manually from the Actions tab
  workflow_dispatch:

# A workflow run is made up of one or more jobs that can run sequentially or in parallel
jobs:
  # This workflow contains a single job called "build"
  build:
    # The type of runner that the job will run on
    runs-on: self-hosted

    # Steps represent a sequence of tasks that will be executed as part of the job
    steps:
      # Checks-out your repository under $GITHUB_WORKSPACE, so your job can access it
      - uses: actions/checkout@v2

      # Runs a single command using the runners shell
      - name: create a .env file 
        run: |
          cd TodoApi
          touch .env
          echo MYSQL_ROOT_PASSWORD=${{secrets.MYSQL_ROOT_PASSWORD}} >> .env
          echo MYSQL_DATABASE=${{secrets.MYSQL_DATABASE}} >> .env
          echo MYSQL_USER=${{secrets.MYSQL_USER}} >> .env
          echo MYSQL_PASSWORD=${{secrets.MYSQL_PASSWORD}} >> .env
          echo PORT=8000 >> .env
          echo MYSQL_CONN_STRING="server=db;database=${{secrets.MYSQL_DATABASE}};user=${{secrets.MYSQL_USER}};password=${{secrets.MYSQL_PASSWORD}};port=3306" >> .env

      # Runs a set of commands using the runners shell
      - name: Run build
        run: |
          cd TodoApi
          docker-compose up -d
```
Finally, commit your code. A build will be triggered automatically. After a successful build, your app will be running on the port specified in the `Dockerfile`.
