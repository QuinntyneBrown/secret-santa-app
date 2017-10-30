using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SecretSantaApp.Features.Core;

namespace SecretSantaApp.Features.Recipients
{
    [Authorize]
    [RoutePrefix("api/recipients")]
    public class RecipientController : BaseApiController
    {
        public RecipientController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateRecipientCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateRecipientCommand.Request request) => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateRecipientCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateRecipientCommand.Request request) => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetRecipientsQuery.Response))]
        public async Task<IHttpActionResult> Get() => Ok(await Send(new GetRecipientsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetRecipientByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetRecipientByIdQuery.Request request) => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveRecipientCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveRecipientCommand.Request request) => Ok(await Send(request));

    }
}
