﻿/**
 *  Represents a Hitbox on an attack or a spell.
 *  
 *  When an attack goes off, it should not be able to hurt -every-
 *  creature in the game. It'd be silly for a player to (typically) get hit
 *  by their own attacks. Hitbox uses Unity's tag system to make sure only
 *  specific targets are considered struck even when the hitbox collides.
 *  
 *  A single hitbox should not be able to strike a target multiple times,
 *  so this class remembers what was already struck so it's not attacked
 *  again.
 *  
 *  Hitboxes should not be reused. They are expected to be generated when an
 *  attack starts and destroyed when an attack ends. Hitboxes are not always
 *  active in games, so it makes sense to just create and destroy them as needed.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace BitzawolfRPG
{
    [System.Serializable]
    public class CollisionEvent : UnityEvent<GameObject> { }

    public class Hitbox : MonoBehaviour
    {
        public AudioClip hitSoundeffect = null;

        private ArrayList targetsHit = new ArrayList();
        private ArrayList validTargetTags = new ArrayList();

        /**
         * An Event spells/attacks can listen to so they can apply
         * Effects to the target this hitbox collides with. This
         * function provides the GameObject that got struck.
         */
        public CollisionEvent onCollision = new CollisionEvent();

        /**
         * Specifies the tag is a valid target for this hitbox and
         * when GameObjects with that tag collide with this hitbox,
         * an onCollision event will fire for that GameObject.
         */
        public void addTargetTag(string tag)
        {
            validTargetTags.Add(tag);
        }

        /**
         * Specifies the tag is no longer a valid target for this hitbox.
         */
        public void removeTargetTag(string tag)
        {
            validTargetTags.Remove(tag);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (validTargetTags.Contains(other.gameObject.tag) && !targetsHit.Contains(other.gameObject))
            {
                if (hitSoundeffect != null)
                {
                    AudioSource.PlayClipAtPoint(hitSoundeffect, other.gameObject.transform.position);
                }
                targetsHit.Add(other.gameObject);
                onCollision.Invoke(other.gameObject);
            }
        }
    }
}