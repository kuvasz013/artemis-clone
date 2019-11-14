using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHelper : MonoBehaviour
{
    private Coroutine fickleShields;
    public static void ApplyDamage(GameObject target, Damage damage)
    {
        //If target has shields, hit them, and finish execution
        if (target.GetComponentInChildren<Shields>())
        {
            Shields shieldHandler = target.GetComponentInChildren<Shields>();
            shieldHandler.Damage(damage);
            return;
        }
    }

}
