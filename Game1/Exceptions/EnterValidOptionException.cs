using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Exceptions
{
    internal class EnterValidOptionException:Exception
    {
        public EnterValidOptionException(string message):base(message)
        {
            
        }
    }
}
