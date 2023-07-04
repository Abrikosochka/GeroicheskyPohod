using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeroicheskyPohod
{
    internal class Сharacter
    {
        public int coins = 0;
        public int health = 15;
        public int power = 5;        
        public void Attack(Enemy enemy)
        {
            enemy.Taking_damage(power);
        }
    }
}
