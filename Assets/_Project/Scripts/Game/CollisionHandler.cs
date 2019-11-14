using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float damageMuliplier;
    public DamageType damageType;

    void OnCollisionEnter(Collision collision)
    {
        //Calculate gross damage done to hit object
        float damageValue = collision.relativeVelocity.magnitude * damageMuliplier;
        Damage damage = new Damage(damageValue, damageType);
        Debug.Log(gameObject.name + " does damage to " + collision.gameObject.name + " : " + damageValue);

        DamageHelper.ApplyDamage(collision.gameObject, damage);
    }
}
