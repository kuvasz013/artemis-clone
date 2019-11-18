using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float flyRange;

    void FixedUpdate()
    {
        //Move the projectile forward
        transform.Translate(transform.forward * Time.fixedDeltaTime * 40, Space.World);

        //If the projectile reaches the max flyRange, destroy it
        if (Vector3.Distance(transform.position, transform.parent.transform.position) >= flyRange)
        {
            Debug.Log("Projectile reached max distance");
            Destroy(gameObject, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject target = collider.gameObject;
        Debug.Log("Hit object: " + target.name);
        //Laser bypasses own shield and other projectiles - otherwise, resolve hit
        if (target.tag != "PlayerShields" && target.tag != "Projectile")
        {
            DamageHelper.ApplyDamage(target, GetComponent<DamageHandler>().damage);
            Destroy(gameObject, 0);
        } else {

            Debug.Log("Bypass hit: " + target.tag);
        }
    }

    public void PassRange(float _flyRange)
    {
        this.flyRange = _flyRange;
    }
}
