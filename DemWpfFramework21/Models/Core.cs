using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemWpfFramework21.Models
{
    public static class Core
    {
        private static Dem21Entities context;
        public static Dem21Entities Context => context ?? (context = new Dem21Entities());

        //public static Dem21Entities Entities { get; set; } = new Dem21Entities();
    }
}
