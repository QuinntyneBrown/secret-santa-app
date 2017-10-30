using System;

namespace SecretSantaApp.Features.Recipients
{
    public class RecipientsCacheKeyFactory
    {
        public static string Get(Guid tenantId) => $"[Recipients] Get {tenantId}";
        public static string GetById(Guid tenantId, int id) => $"[Recipients] GetById {tenantId}-{id}";
    }
}
