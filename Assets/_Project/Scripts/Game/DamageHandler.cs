using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float damagePerShot;
    public DamageType damageType;
    public Damage damage;

    void Start()
    {
        damage = new Damage(damagePerShot, damageType);
    }
}
