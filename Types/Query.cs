using HotChocolate.Subscriptions;
using HotChocolate.Subscriptions.Diagnostics;

namespace hcsubscriptions.Types;

[QueryType]
public static class Query
{
    public static Book GetBook()
        => new Book("1", "C# in depth.", new Author("Jon Skeet"));
}

[SubscriptionType]
public class Subscriptions
{
    [Subscribe]
    [Topic($"{{id}}_{nameof(Book)}")]
    public Book BookUpdated(string id,
    [EventMessage] Book book) => book;
}

[MutationType]
public class Mutations
{
    public PagesBook AddPagesBook(
    PagesBook input,
    [Service] ITopicEventSender sender,
    CancellationToken token)
    {
        sender.SendAsync($"{input.Id}_{nameof(Book)}", input, token);
        return input;
    }

    public AnotherBook AddAnotherBook(
    AnotherBook input,
    [Service] ITopicEventSender sender,
    CancellationToken token)
    {
        sender.SendAsync($"{input.Id}_{nameof(Book)}", input, token);
        return input;
    }

    public class SomeSubscriptionDiagnosticEventsListener : SubscriptionDiagnosticEventsListener
    {
        public override void Created(string topicName) => Console.WriteLine($"{topicName} topic created.");
    }
}
