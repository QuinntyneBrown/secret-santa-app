using System.Data.Entity.Migrations;
using SecretSantaApp.Data;

namespace SecretSantaApp.Data.Migrations
{
    public class ProfileConfiguration
    {
        public static void Seed(SecretSantaAppContext context) {

            context.SaveChanges();
        }
    }
}
