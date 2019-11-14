using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private SelectionController selection;
    public GameObject laserCannon;

    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponent<SelectionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selection.GetCurrentTarget() != null)
            {
                StartCoroutine(
                    RenderCannon(
                        selection.GetCurrentTarget().transform));
            }
        }
    }

    IEnumerator RenderCannon(Transform target)
    {
        GameObject laserInstance = (GameObject)Instantiate(laserCannon);
        laserInstance.GetComponent<AudioSource>().Play();

        LaserCannon laserScript = laserInstance.GetComponent<LaserCannon>();
        laserScript.startPoint = transform;
        laserScript.endPoint = target;
        yield return new WaitForSeconds(2);
        Destroy(laserInstance);
    }
}
