/**
 * Creature represents a single being in the game that has some initial attributes
 * and can gain Effects like those from being hit by a weapon or spell.
 */

using UnityEngine;
using System.Collections;

namespace BitzawolfRPG
{
    public class Creature : MonoBehaviour
    {
        protected Attributes baseAttributes = new Attributes();
        private ArrayList listOfEffects = new ArrayList();

        /**
         * Returns a copy of this creature's base attributes. The copy is to ensure
         * that the creature's attributes cannot be modified outside of this class.
         */
        public Attributes getBaseAttributes()
        {
            return baseAttributes.clone();
        }

        /**
         * Sets the creature's base attributes to match the attributes passed in.
         * Any previous base attributes are permanently lost.
         */
        public void setBaseAttributes(Attributes attributes)
        {
            baseAttributes = attributes.clone();
        }

        /**
         * Permanently changes the inherit attributes of this creature. Ideally this function would
         * be used for level-ups or other permanent changes to the creature.
         */
        public void modifyBaseAttributes(Attributes modification)
        {
            baseAttributes += modification;
        }

        /**
         * Retrieves the attributes that represent this creature's initial attributes plus
         * all of the effects currently on the creature. This represents the current state of
         * the creature.
         */
        public Attributes getCurrentAttributes()
        {
            Attributes current = baseAttributes.clone();
            foreach (Effect eff in listOfEffects)
            {
                current += eff.getAttributeChange();
            }

            return current;
        }

        public void addEffect(Effect newEffect)
        {
            foreach (Effect curEffect in listOfEffects)
            {
                if (curEffect.combine(newEffect))
                    return;
            }
            listOfEffects.Add(newEffect);
        }

        public bool isDead()
        {
            return (getCurrentAttributes().health <= 0);
        }
    }
}
