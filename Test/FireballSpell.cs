using UnityEngine;
using BitzawolfRPG;

public class FireballSpell : MonoBehaviour
{
    private Hitbox hitbox;
    
	void Start()
    {
        hitbox = GetComponent<Hitbox>();
        hitbox.onCollision.AddListener(onHit);
        hitbox.addTargetTag("Enemy");
	}

    private void onHit(GameObject go)
    {
        Debug.Log("Fireball hit " + go.name);
        go.GetComponent<Creature>().addEffect(new DamageHealthEffect(10));
    }
}
