using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelprojekt.Entities
{
    public class Identity
    {
        public int Id { get; set; }

        public List<Player> Players { get; set; }

        public string Name { get; set; }

        
    }
}
