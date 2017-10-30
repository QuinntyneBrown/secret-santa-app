using System;
using SecretSantaApp.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSantaApp.Model
{
    [SoftDelete("IsDeleted")]
    public class Recipient: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }

        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
        
        public virtual Profile Profile { get; set; }
    }
}
