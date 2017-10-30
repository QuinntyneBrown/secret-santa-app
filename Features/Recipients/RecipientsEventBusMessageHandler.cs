using SecretSantaApp.Features.Core;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using System;

namespace SecretSantaApp.Features.Recipients
{
    public interface IRecipientsEventBusMessageHandler: IEventBusMessageHandler { }

    public class RecipientsEventBusMessageHandler: IRecipientsEventBusMessageHandler
    {
        public RecipientsEventBusMessageHandler(ICache cache)
        {
            _cache = cache;
        }

        public void Handle(JObject message)
        {
            try
            {
                if ($"{message["type"]}" == RecipientsEventBusMessages.AddedOrUpdatedRecipientMessage)
                {
                    _cache.Remove(RecipientsCacheKeyFactory.Get(new Guid(message["tenantUniqueId"].ToString())));
                }

                if ($"{message["type"]}" == RecipientsEventBusMessages.RemovedRecipientMessage)
                {
                    _cache.Remove(RecipientsCacheKeyFactory.Get(new Guid(message["tenantUniqueId"].ToString())));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private readonly ICache _cache;
    }
}
