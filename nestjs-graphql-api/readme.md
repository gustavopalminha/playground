# **nestjs-graphql-api**

## **Description**
Sample nestjs project with graphql api to play with.

Uses code first approach.

## **How to run**

Clone repo or download source code project to local.

Node v: 18.12.0

Install dependencies:
```bash
$ npm install
```

Run the app:

```bash
# development
$ npm run start
```

Open [grapql-editor](http://localhost:3000/graphql) and follow instructions bellow to read all blogs and add one

To retrieve all the blogs from the database, run the query below:

```grapql
query getAll{
  getAllBlogs {
    id,
    title,
    body,
    author,
    date
  }
}
```

To add one blog:
```grapql
mutation createBlog {
  createBlog (blogInput: {
    id: 1, 
    title: "GraphQL is great", 
    body: "GraphQL APIs are faster than REST APIs", 
    author: "David Ekete",
    date: "01-02-03"
  }) {
    id,
    title,
    body,
    author,
    date,
  }
}
```

## **References**
[How to Build a GraphQL API with Nest.js](https://blog.back4app.com/nestjs-graphql/)
