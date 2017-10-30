using MediatR;
using SecretSantaApp.Data;
using SecretSantaApp.Model;
using SecretSantaApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace SecretSantaApp.Features.Recipients
{
    public class RemoveRecipientCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public int Id { get; set; }
            public Guid CorrelationId { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SecretSantaAppContext context, IEventBus bus)
            {
                _context = context;
                _bus = bus;
            }

            public async Task<Response> Handle(Request request)
            {
                var recipient = await _context.Recipients.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                recipient.IsDeleted = true;
                await _context.SaveChangesAsync();
                _bus.Publish(new RemovedRecipientMessage(request.Id, request.CorrelationId, request.TenantUniqueId));
                return new Response();
            }

            private readonly SecretSantaAppContext _context;
            private readonly IEventBus _bus;
        }
    }
}
