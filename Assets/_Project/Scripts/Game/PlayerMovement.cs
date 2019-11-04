using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ship;
    private Vector3 shipRotation;
    private Vector3 angVel;
    public float maneuvering;
    public float thrust;
    public Vector3 cameraOffset;
    private float speed;
    public float maxSpeed;
    public Rigidbody rb;
    
    // --- temporary ---
    public Text text;

    void FixedUpdate()
    {
        // ANGULAR DYNAMICS

        angVel.x += Input.GetAxis("Vertical") * Mathf.Abs(Input.GetAxis("Vertical")) * maneuvering * Time.fixedDeltaTime;

        float turn = Input.GetAxis("Horizontal") * Mathf.Abs(Input.GetAxis("Horizontal")) * maneuvering * Time.fixedDeltaTime;
        angVel.z -= turn;

        angVel /= 1 + speed * .001f;
        angVel -= angVel.normalized * angVel.sqrMagnitude * .1f * Time.fixedDeltaTime;


        transform.Rotate(angVel * Time.deltaTime);


        // LINEAR DYNAMICS

        float acceleration = Input.GetAxis("Thrust");
        speed += acceleration * Mathf.Abs(acceleration) * thrust * Time.fixedDeltaTime;

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed <= 0)
        {
            speed = 0;
        }

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);


        // CAMERA UPDATE

        transform.GetChild(0).localPosition = cameraOffset;

        // TEXT UPDATE
        text.text = "Speed: " + Mathf.RoundToInt(speed);

    }
}
