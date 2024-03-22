# “Dockerize” Your Next.js Application

### Taken from: [https://medium.com/@raditskc/dockerize-your-next-js-application-816e8a979501](https://medium.com/@raditskc/dockerize-your-next-js-application-816e8a979501)

### Intro
Running applications in Docker offers significant benefits for software development and deployment. Docker enables application isolation by packaging applications and dependencies into portable containers. This simplifies deployment across different environments, ensures consistency, and reduces conflicts. Docker also promotes reproducibility by sharing pre-configured Docker images, ensuring reliable deployments. In simpler words, it almost guarantees the absence of the “It runs in my computer, why doesn’t it run in <other device other than the said computer>, bro?” issue, all thanks to the outstanding environment consistency that Docker containers provide.

This guide will walk you through the process of dockerizing your Next.js project, enabling you to package it as a Docker image and run it in a containerized environment. If you’re in a hurry or you’re an impatient person, you may skip to the end of this article to see the full `Dockerfile` and `docker-compose.yml` files. Here are the steps:

1.  Create a `Dockerfile` in the root directory of your Next.js project. Create a file named `Dockerfile` (without any file extension).
2.  Define the Base Image for your Docker container. Specify the desired version of Node.js by including `node:18` for Node.js version 18 using the `FROM` instruction.
3.  Set the Working Directory. Using the `WORKDIR` instruction, specify the path where your Next.js project will be copied inside the container.
4.  Install Dependencies: Copy the `package.json` and `package-lock.json` files to the container’s working directory. Run `npm install` using the `RUN` instruction inside the container to install the project dependencies.
5.  Copy Project Files the project files to the container’s working directory using the `COPY` instruction.
6.  Build the Next.js Application. Run the appropriate build command for your Next.js project inside the container using `npm run build` with the `RUN` instruction.
7.  Expose the Port using the `EXPOSE` instruction. The default port is usually 3000.
8.  Start the Next.js Application. Using `CMD` instruction, specify the default command that will be executed when a container is run based on the image: `CMD ["npm", "run", "start"]`

Your `Dockerfile` will look like this:

```
FROM node:14

WORKDIR /app

COPY package.json package-lock.json ./
RUN npm install

COPY . .

RUN npm run build

EXPOSE 3000

CMD ["npm", "run", "start"]
```

And the `docker-compose.yml` will look like this:

```
version: '1'

services:
  next-app:
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - '3000:3000'
    volumes:
      - .:/app
    environment:
      - NODE_ENV=production
```

To run the application, you need to run the following command in your terminal/command prompt:

```
docker-compose up -d
```

But if you’re running it for the first time, include the `--build` flag, too.

Whether you’re deploying to a local development environment or a production server, Docker enables you to streamline the deployment process and ensure consistent execution of your Next.js application. Embracing Dockerization empowers you to efficiently manage and distribute your Next.js projects, making it an invaluable tool for modern web development workflows.
