using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 angVel;
    public float maneuvering;
    public float thrust;
    public Vector3 cameraOffset;
    private Camera mainCamera;
    private float speed;
    public float maxSpeed;
    private Rigidbody rb;
    private PulseController pulseController;

    // --- temporary ---
    public Text text;


    void Start() {
        Cursor.visible = true;
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        pulseController = GetComponentInChildren<PulseController>();
    }
    void FixedUpdate()
    {
        // ANGULAR DYNAMICS

        angVel.x += Input.GetAxis("Vertical") * Mathf.Abs(Input.GetAxis("Vertical")) * maneuvering * Time.fixedDeltaTime;
        angVel.y += Input.GetAxis("Yaw") * Mathf.Abs(Input.GetAxis("Yaw")) * maneuvering / 2 * Time.fixedDeltaTime;
        angVel.z -= Input.GetAxis("Horizontal") * Mathf.Abs(Input.GetAxis("Horizontal")) * maneuvering * Time.fixedDeltaTime;

        angVel /= 1 + speed * .001f;
        angVel -= angVel.normalized * angVel.sqrMagnitude * .1f * Time.fixedDeltaTime;


        transform.Rotate(angVel * Time.fixedDeltaTime);


        // LINEAR DYNAMICS

        float acceleration = Input.GetAxis("Thrust");
        speed += acceleration * Mathf.Abs(acceleration) * thrust * Time.fixedDeltaTime;;

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed <= 0)
        {
            speed = 0;
            rb.velocity = rb.velocity * .99f;
            rb.angularVelocity = rb.angularVelocity * .99f;
        }

        transform.Translate(transform.forward * speed * Time.fixedDeltaTime, Space.World);


        // CAMERA UPDATE

        mainCamera.transform.localPosition = cameraOffset;
        pulseController.HandleExhaust(acceleration);

        // TEXT UPDATE
        text.text = "Speed: " + Mathf.RoundToInt(speed);

    }
}
