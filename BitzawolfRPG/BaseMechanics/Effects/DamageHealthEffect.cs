/**
 * Represents a fundamental effect of any RPG - taking damage. Decreases a
 * creature's health points by some amount.
 */
namespace BitzawolfRPG
{
    public class DamageHealthEffect : Effect
    {
        private int damageAmount;

        public DamageHealthEffect(int amount)
        {
            if (amount < 0)
                amount *= -1;
            damageAmount = amount;
        }

        public override Attributes getAttributeChange()
        {
            return new Attributes(-damageAmount);
        }

        public override bool combine(Effect other)
        {
            if (other is DamageHealthEffect)
            {
                DamageHealthEffect otherDamage = (DamageHealthEffect)other;
                damageAmount += otherDamage.damageAmount;
                return true;
            }
            return false;
        }
    }
}