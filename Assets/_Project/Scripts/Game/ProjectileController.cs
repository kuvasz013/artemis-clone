using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * Time.fixedDeltaTime * 40, Space.World);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject, 0);
        Debug.Log("Laser destroyed");
    }
}
