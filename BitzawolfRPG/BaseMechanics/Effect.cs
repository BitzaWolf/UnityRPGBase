/**
 * Effects represents a status change to a creature. Mainly a change in attributes on a player.
 * Can also mean recurring change where the attributes change over time.
 * 
 * Effects are designed to be held/owned by the creature they're affecting. The creature
 * will check the list of Effects it has to determine its status as a whole.
 *
 * Effects are generated each time a creature gets attacked or connects with an effect or
 * gets an effect applied at all. This means a creature could have multiple of the same
 * effects at one time.
 * 
 * The purpose of this system is to allow for an easy way to dertmine a creature's current
 * state and allow for harmful effects to be purged/cleansed easily. Additionally, this system
 * will allow for neat mechanics where a creature can heal/cure specific effects
 * instead of the typical numeric healing amounts.
 * 
 * Potentially this class could be expanded to combine effects if they're the same type on the
 * same creature, which would allow for more traditional HP/MP counters.
 * 
 * Status conditions like Frozen or Burning would not make sense as effects and are not handled
 * here. Damage from burning would be here, but handling weird situations where a creature could
 * be both burning and frozen is silly and hard to do here. Instead, it would be nice to create a
 * new Condition class where a creature can only have 1 condition at a time.
 */
namespace BitzawolfRPG
{
    public abstract class Effect
    {
        protected string name { get; set; }
        protected string description { get; set; }

        abstract public Attributes getAttributeChange();

        /**
         * Combines another effect into this one, returning true if the effect was
         * successfully added into this effect. This is to enable situations where
         * a creature could be given two similar Effects and it would make more sense
         * to combine them into a single stronger effect instead of having two nearly identical
         * effects at the same time.
         * 
         * For example, if the creature had a poison effect and a new poison effect
         * should be added, we could combine them such that the first poison effect
         * becomes stronger (or gets its duration refreshed) then the new poison
         * effect would get deleted.
         */
        virtual public bool combine(Effect other)
        {
            return false;
        }
    }
}