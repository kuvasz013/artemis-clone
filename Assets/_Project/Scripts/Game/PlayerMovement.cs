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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotateVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float rotateHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime * speed;

        player.transform.Translate(0, 0, thrust);
        //mainCamera.transform.Translate(moveHorizontal, moveVertical, thrust);
    }
}
