using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PeTelecom.BuildingBlocks.Application.Configuration.Commands;

namespace PeTelecom.Modules.UserAccess.Application.Outbox
{
    internal class ProcessOutboxCommandHandler : ICommandHandler<ProcessOutboxCommand>
    {
        private readonly IMediator _mediator;
        private readonly IOutboxDatabaseQueries _databaseQueries;

        public ProcessOutboxCommandHandler(IMediator mediator, IOutboxDatabaseQueries databaseQueries)
        {
            _mediator = mediator;
            _databaseQueries = databaseQueries;
        }

        public async Task<Unit> Handle(ProcessOutboxCommand command, CancellationToken cancellationToken)
        {
            var messages = await _databaseQueries.GetUnprocessedMessages();

            var outboxMessages = messages.ToList();
            if (outboxMessages.Any())
            {
                foreach (var message in outboxMessages)
                {
                    var type = typeof(ProcessOutboxCommandHandler)
                        .Assembly
                        .GetType(message.Type);

                    // TODO: do i need to cast this to IDomainEventNotification?
                    var request = JsonSerializer.Deserialize(message.Data, type);

                    await _mediator.Publish(request, cancellationToken);
                    await _databaseQueries.UpdateProcessDate(message.Id, DateTime.UtcNow);

                    // TODO: check the commented code.
                    //using (LogContext.Push(new OutboxMessageContextEnricher(request)))
                    //{
                    //    await this._mediator.Publish(request, cancellationToken);

                    //    await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                    //    {
                    //        Date = DateTime.UtcNow,
                    //        message.Id
                    //    });
                    //}

                }
            }

            return Unit.Value;
        }
    }
}
