using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void FixedUpdate()
    {
        //Move the projectile forward
        transform.Translate(transform.forward * Time.fixedDeltaTime * 40, Space.World);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject target = collider.gameObject;

        //Laser bypasses own shield and other projectiles - otherwise, resolve hit
        if (target.tag != "PlayerShields" && target.tag != "Projectile")
        {
            DamageHelper.ApplyDamage(target, GetComponent<DamageHandler>().damage);
            Destroy(gameObject, 0);
        }
    }
}
