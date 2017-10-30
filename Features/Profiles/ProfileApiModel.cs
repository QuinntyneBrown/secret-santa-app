using SecretSantaApp.Model;
using System.Collections.Generic;

namespace SecretSantaApp.Features.Profiles
{
    public class ProfileApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<Recipient> Recipients { get; set; }

        public static TModel FromProfile<TModel>(Profile profile) where
            TModel : ProfileApiModel, new()
        {
            var model = new TModel();
            model.Id = profile.Id;
            model.TenantId = profile.TenantId;
            model.Firstname = profile.Firstname;
            model.Lastname = profile.Lastname;
            return model;
        }

        public static ProfileApiModel FromProfile(Profile profile)
            => FromProfile<ProfileApiModel>(profile);

    }
}
