using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{

    private Camera mainCamera;
    private GameObject currentTarget;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Selectable")
                {
                    currentTarget = hit.transform.gameObject;
                    text.text = "Currently Selected: " + currentTarget.GetComponent<ObjectController>().callSign;
                }
            }
        }
    }

    GameObject getCurrentTarget() 
    {
        return currentTarget;
    }
}
