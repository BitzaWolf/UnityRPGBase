/**
 * Creature represents a single being in the game that has some initial attributes
 * and can gain Effects like those from being hit by a weapon or spell.
 */

using System.Collections;

namespace BitzawolfRPG
{
    public class Creature
    {
        protected Attributes baseAttributes;
        private ArrayList listOfEffects = new ArrayList();

        public Creature(Attributes attributes)
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

        public void addEffect(Effect e)
        {
            listOfEffects.Add(e);
        }
    }
}
