# hcsubscriptions
Sample project to demonstrate interface subscriptions issue


1. Subscribe to `BookUpdated` with the follwing arguments.

```gql

subscription BookUpdated {
  bookUpdated(id: "2") {
    ... on PagesBook {
      title
      author {
        name
      }
      pages
    }
    ... on AnotherBook {
      title
      author {
        name
      }
      another
    }
  }
}

```

2. Run  `AddPagesBook` with the follwing arguments.

```gql

mutation AddPagesBook {
  addPagesBook(
    input: { id: "2", author: { name: "name" }, pages: 100, title: "title1" }
  ) {
    title
    author {
      name
    }
    pages
  }
}

```

3.  Run  `AddAnotherBook`  with the follwing arguments which throws an exeption.
   
   The exception can occur in either `AddPagesBook` or `AddAnotherBook` mutation depending on which id value is passed to `BookUpdated` subscription.

```
InvalidMessageTypeException: 'The topic already exists with a different message type. Topic message type: hcsubscriptions.Types.Book. Requested message type: hcsubscriptions.Types.AnotherBook.'

```
```gql
mutation AddAnotherBook {
  addAnotherBook(
    input: {
      id: "3"
      author: { name: "name" }
      another: "another"
      title: "title2"
    }
  ) {
    title
    author {
      name
    }
    another
  }
}
```
