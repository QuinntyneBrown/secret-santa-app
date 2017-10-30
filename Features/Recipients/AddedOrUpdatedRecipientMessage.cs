using SecretSantaApp.Model;
using SecretSantaApp.Features.Core;
using System;

namespace SecretSantaApp.Features.Recipients
{

    public class AddedOrUpdatedRecipientMessage : BaseEventBusMessage
    {
        public AddedOrUpdatedRecipientMessage(Recipient recipient, Guid correlationId, Guid tenantId)
        {
            Payload = new { Entity = recipient, CorrelationId = correlationId };
            TenantUniqueId = tenantId;
        }
        public override string Type { get; set; } = RecipientsEventBusMessages.AddedOrUpdatedRecipientMessage;        
    }
}
