using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    private SelectionController selection;

    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponentInParent<SelectionController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (selection.GetCurrentTarget() != null)
            {
                GetComponent<AudioSource>().Play();

                target = selection.GetCurrentTarget().transform;
                GameObject instance = (GameObject)Instantiate(projectile);
                instance.transform.position = transform.position;
                instance.GetComponent<ProjectileController>().direction = target.position - transform.position;
            }
        }
    }
}
