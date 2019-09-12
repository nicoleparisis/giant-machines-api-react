# React Frontend .Net Core API Backend

Please make sure nothing is running on your port 1433 (SQL), 3000, or 5000 because this will interfere with the docker containers

You will need docker installed and running on your computer.

You do not need to clone the repository because the docker containers are pushed up to my docker hub repo but you will need the docker-compose file. Type the following command in a terminal to run all containers

```console
docker-compose up -d
```

The front end application is located at http://localhost:3000/

The API also has a front end at http://localhost:5000/swagger/index.html