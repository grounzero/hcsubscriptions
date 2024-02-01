using hcsubscriptions.Types;
using static hcsubscriptions.Types.Mutations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddDiagnosticEventListener<SomeSubscriptionDiagnosticEventsListener>()
    .AddInMemorySubscriptions()
    .AddTypes()
    .AddType<AnotherBook>()
    .AddType<PagesBook>();

var app = builder.Build();
app.UseWebSockets();
app.MapGraphQL();
app.RunWithGraphQLCommands(args);
