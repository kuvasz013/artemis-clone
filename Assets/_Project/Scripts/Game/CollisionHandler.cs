using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float damageMuliplier = 10;
    public DamageType damageType = DamageType.normal;
    public float maxDamage = 80;

    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        //Calculate gross damage done to hit object
        float damageValue = Mathf.Log10((collision.impulse / Time.fixedDeltaTime).magnitude) *  damageMuliplier;

        // Fix damage to maximum collision damage
        damageValue = damageValue > maxDamage ? maxDamage : damageValue;

        //Apply calculated damage
        Damage damage = new Damage(damageValue, damageType);
        DamageHelper.ApplyDamage(collision.gameObject, damage);
    }
}
