using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;

namespace PeTelecom.Modules.UserAccess.Application.Inbox
{
    internal class ProcessInboxCommandHandler : ICommandHandler<ProcessInboxCommand>
    {
        private readonly IMediator _mediator;
        private readonly IInboxMessageDatabaseQueries _inboxMessageDatabaseQueries;

        public ProcessInboxCommandHandler(IMediator mediator, IInboxMessageDatabaseQueries inboxMessageDatabaseQueries)
        {
            _mediator = mediator;
            _inboxMessageDatabaseQueries = inboxMessageDatabaseQueries;
        }
        public async Task<Unit> Handle(ProcessInboxCommand command, CancellationToken cancellationToken)
        {
            var messages = await _inboxMessageDatabaseQueries.GetUnprocessedMessagesAsync();

            foreach (var message in messages)
            {
                var messageAssembly = AppDomain.CurrentDomain.GetAssemblies()
                    .First(
                        assembly => message.Type.Contains(assembly.GetName().Name, StringComparison.Ordinal));

                Type type = messageAssembly.GetType(message.Type);
                var request = JsonSerializer.Deserialize(message.Data, type);

                // TODO: Do I need to cast request variable to INotification?
                await _mediator.Publish(request, cancellationToken);

                await _inboxMessageDatabaseQueries.UpdateProcessedDateAsync(message.Id, DateTime.UtcNow);
            }

            return Unit.Value;
        }
    }
}
