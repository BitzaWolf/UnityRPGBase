/**
 * Attributes represents a group of statistics that creatures have in
 * a typical RPG game.
 */

namespace BitzawolfRPG
{
    public class Attributes
    {
        public int health { get; private set; }
        public int mana { get; private set; }
        public int strength { get; private set; }
        public int intelligence { get; private set; }
        public int agility { get; private set; }
        public int defense { get; private set; }
        public int resitance { get; private set; }
        public int experience { get; private set; }

        public Attributes(int hp = 0, int mp = 0, int str = 0, int intel = 0, int agi = 0, int def = 0, int res = 0, int exp = 0)
        {
            health = hp;
            mana = mp;
            strength = str;
            intelligence = intel;
            agility = agi;
            defense = def;
            resitance = res;
            experience = exp;
        }

        public static Attributes operator +(Attributes a, Attributes b)
        {
            return new Attributes(
                a.health + b.health,
                a.mana + b.mana,
                a.strength + b.strength,
                a.intelligence + b.intelligence,
                a.agility + b.agility,
                a.defense + b.defense,
                a.resitance + b.resitance,
                a.experience + b.experience
            );
        }

        public static Attributes operator -(Attributes a, Attributes b)
        {
            return a + (b * -1);
        }

        public static Attributes operator *(Attributes a, int scalar)
        {
            return new Attributes(
                a.health * scalar,
                a.mana * scalar,
                a.strength * scalar,
                a.intelligence * scalar,
                a.agility * scalar,
                a.defense * scalar,
                a.resitance * scalar,
                a.experience * scalar
            );
        }

        public static bool operator ==(Attributes a, Attributes b)
        {
            return (
                a.health == b.health &&
                a.mana == b.mana &&
                a.strength == b.strength &&
                a.intelligence == b.intelligence &&
                a.agility == b.agility &&
                a.defense == b.defense &&
                a.resitance == b.resitance &&
                a.experience == b.experience
            );
        }

        public static bool operator !=(Attributes a, Attributes b)
        {
            return (!(a == b));
        }

        public Attributes clone()
        {
            return new Attributes(
                health,
                mana,
                strength,
                intelligence,
                agility,
                defense,
                resitance,
                experience
            );
        }

        public override bool Equals(object other)
        {
            if (other is Attributes)
            {
                Attributes otherAttr = (Attributes)other;
                return (this == otherAttr);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}