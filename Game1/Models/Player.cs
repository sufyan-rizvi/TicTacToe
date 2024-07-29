using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game1.Models
{
    internal class Player
    {
        public int PlayerId { get; set; }
        public string PlayerMark { set; get; }

        public Player(int id)
        {
            PlayerId = id;
        }
    }
}
