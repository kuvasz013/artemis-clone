using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public Camera mainCamera;
    public float speed;
    private float thrust;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Object Start");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
 
        player.transform.Translate(moveHorizontal, moveVertical, 0);
        mainCamera.transform.Translate(moveHorizontal, moveVertical, 0);
    }
}
