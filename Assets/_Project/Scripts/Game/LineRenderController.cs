using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private SelectionController selection;
    private GameObject turret;
    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lineRenderer.SetPosition(0, transform.parent.position);
        lineRenderer.SetPosition(1, selection.GetCurrentTarget().transform.position);
    }

    public void SetWidth(float startWidth, float endWidth)
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
    }

    public void SetSelection(SelectionController selectionController)
    {
        selection = selectionController;
    }
}
