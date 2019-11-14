using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{

    private Camera mainCamera;
    private GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.transform.gameObject;
                if (target.tag == "Selectable")
                {
                    if (target.GetComponent<Shields>() != null)
                    {
                        currentTarget = hit.transform.parent.gameObject;
                    }
                    else
                    {
                        currentTarget = hit.transform.gameObject;
                    }
                }
            }
        }
    }

    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }
}
