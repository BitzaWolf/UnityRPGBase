/**
 * Attributes represents a group of statistics that creatures have in
 * a typical RPG game.
 */

namespace BitzawolfRPG
{
    public class Attributes
    {
        private int health { get; set; }
        private int mana { get; set; }
        private int strength { get; set; }
        private int intelligence { get; set; }
        private int agility { get; set; }
        private int defense { get; set; }
        private int resitance { get; set; }
        private int experience { get; set; }

        public Attributes(int hp = 0, int mp = 0, int str = 0, int agi = 0, int def = 0, int res = 0, int exp = 0)
        {
            health = hp;
            mana = mp;
            strength = str;
            agility = agi;
            defense = def;
            resitance = res;
            experience = exp;
        }

        public static Attributes operator +(Attribute a, Attribute b)
        {
            return new Attributes(
                a.health + b.health,
                a.mana + b.mana,
                a.strength + b.strength,
                a.agility + b.agility,
                a.defense + b.defense,
                a.resitance + b.resitance,
                a.experience + b.experience
            );
        }

        public static Attributes operator -(Attribute a, Attribute b)
        {
            return a + (b * -1);
        }

        public static Attributes operator *(Attribute a, int scalar)
        {
            return new Attributes(
                a.health * scalar,
                a.mana * scalar,
                a.strength * scalar,
                a.agility * scalar,
                a.defense * scalar,
                a.resitance * scalar,
                a.experience * scalar
            );
        }
    }
}