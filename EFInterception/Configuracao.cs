using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFInterception
{
    public class Configuracao : DbConfiguration
    {
        public Configuracao()
        {
            this.AddInterceptor(new InterceptaSQL());
        }
    }
    
}
