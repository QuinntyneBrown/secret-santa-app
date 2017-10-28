using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaApp.Features.Core
{
    public interface ICacheProvider
    {
        ICache GetCache();
    }
}
