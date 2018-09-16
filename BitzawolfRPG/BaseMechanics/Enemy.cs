using LDJ41;

namespace BitzawolfRPG
{
    public abstract class Enemy : Creature
    {
        public bool isSmitten = false;
        public CollisionEvent onCollision = new CollisionEvent();
        public abstract void initiateTurn();

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (isSmitten || GameManager.get().isInBattle)
                return;

            if (collision.gameObject.tag == "Player")
            {
                onCollision.Invoke(gameObject);
            }
        }
    }
}