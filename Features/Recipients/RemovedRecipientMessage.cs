using SecretSantaApp.Features.Core;
using System;

namespace SecretSantaApp.Features.Recipients
{
    public class RemovedRecipientMessage : BaseEventBusMessage
    {
        public RemovedRecipientMessage(int recipientId, Guid correlationId, Guid tenantId)
        {
            Payload = new { Id = recipientId, CorrelationId = correlationId };
            TenantUniqueId = tenantId;
        }
        public override string Type { get; set; } = RecipientsEventBusMessages.RemovedRecipientMessage;        
    }
}
