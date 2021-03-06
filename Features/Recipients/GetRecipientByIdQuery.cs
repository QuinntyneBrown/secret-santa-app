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
    public class GetRecipientByIdQuery
    {
        public class Request : BaseRequest, IRequest<Response> { 
            public int Id { get; set; }            
        }

        public class Response
        {
            public RecipientApiModel Recipient { get; set; } 
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
                return new Response()
                {
                    Recipient = RecipientApiModel.FromRecipient(await _context.Recipients
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly SecretSantaAppContext _context;
            private readonly ICache _cache;
        }

    }

}
