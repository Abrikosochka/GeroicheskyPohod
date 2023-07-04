using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroicheskyPohod
{
    internal class Options
    {
        public int level = 1;
        public bool game_over = false;
        public Options(int level, bool game_over)
        {
            this.level = level;
            this.game_over = game_over;
        }
    }
}
