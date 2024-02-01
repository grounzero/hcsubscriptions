# hcsubscriptions
Sample project to demonstrate interface subscriptions issue

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
