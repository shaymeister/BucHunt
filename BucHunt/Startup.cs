using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
//This is a test
[assembly: OwinStartup(typeof(BucHunt.Startup))]

namespace BucHunt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
