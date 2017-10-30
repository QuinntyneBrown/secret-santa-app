using SecretSantaApp.Model;

namespace SecretSantaApp.Features.Recipients
{
    public class RecipientApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public int? ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public static TModel FromRecipient<TModel>(Recipient recipient) where
            TModel : RecipientApiModel, new()
        {
            var model = new TModel();
            model.Id = recipient.Id;
            model.TenantId = recipient.TenantId;
            model.Lastname = recipient.Firstname;
            model.Lastname = recipient.Lastname;
            model.ProfileId = recipient.ProfileId;
            return model;
        }

        public static RecipientApiModel FromRecipient(Recipient recipient)
            => FromRecipient<RecipientApiModel>(recipient);

    }
}
