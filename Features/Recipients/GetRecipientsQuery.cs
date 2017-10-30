using MediatR;
using SecretSantaApp.Data;
using SecretSantaApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace SecretSantaApp.Features.Recipients
{
    public class GetRecipientsQuery
    {
        public class Request : BaseRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<RecipientApiModel> Recipients { get; set; } = new HashSet<RecipientApiModel>();
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SecretSantaAppContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var recipients = await _context.Recipients
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new Response()
                {
                    Recipients = recipients.Select(x => RecipientApiModel.FromRecipient(x)).ToList()
                };
            }

            private readonly SecretSantaAppContext _context;
            private readonly ICache _cache;
        }
    }
}
