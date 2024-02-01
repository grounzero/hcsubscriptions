namespace hcsubscriptions.Types;

[InterfaceType(nameof(Book))]
public record Book(string Id, string Title, Author Author);

public record PagesBook(string Id, string Title, Author Author, int Pages) : Book(Id, Title, Author);

public record AnotherBook(string Id, string Title, Author Author, string Another) : Book(Id, Title, Author);