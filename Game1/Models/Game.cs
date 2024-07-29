using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Models
{
    internal static class Game
    {
        public static int NumberOfRows { get; } = 3;
        public static int NumberOfColumns { get; } = 3;

        public static int MovesPlayed { set; get; } = 1;
    }
}
