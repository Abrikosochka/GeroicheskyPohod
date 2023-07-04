using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GeroicheskyPohod
{
    abstract internal class Enemy
    {
        abstract public void Taking_damage(int damage);
        abstract public void Attack(Сharacter character);
    }
    internal class Goblin : Enemy
    {
        public int health = 10;
        public int power = 3;
        public override void Attack(Сharacter character)
        {
            character.health -= power;
        }
        public override void Taking_damage(int damage)
        {
            health -= damage;
        }
    }
    internal class Catfish : Enemy
    {
        public int health = 15;
        public int power = 5;
        public override void Attack(Сharacter character)
        {
            character.health -= power;
        }
        public override void Taking_damage(int damage)
        {
            health -= damage;
        }
    }
    internal class Yeti : Enemy
    {
        public int health = 20;
        public int power = 6;
        public override void Attack(Сharacter character)
        {
            character.health -= power;
        }
        public override void Taking_damage(int damage)
        {
            health -= damage;
        }
    }
}
