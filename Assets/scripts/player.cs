using Mythmatic.TurretSystem;
using Unity.VisualScripting;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 4f;

    HomingProjectile turrentcontroller;

    [Header("Mouse Look Settings")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float maxLookAngle = 90f;
    [SerializeField] private float jforce;
    private bool issprinting = false;
    private int sprint = 1;
    bool isgrounded;
    public float stamina = 100f;
    public static int gundamage = 10;

    public static bool shooting = false;

    public static int playerhealth = 100;



    bool jumpkey;

    private Rigidbody rb;
    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    public TurretController turretcontroller;

    public static bool isinenemyzone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        HandleMouseLook();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpkey = true;
        }
        isshooting();
        fromturrent();




    }

    private void FixedUpdate()

    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            issprinting = true;
            if (issprinting)
            {
                if (stamina > 0.1000000f)
                {
                    sprint = 2;
                    stamina -= .8f;
                }
                else
                {
                    sprint = 1;
                }
            }

        }
        else
        {
            issprinting = false;
            sprint = 1;
            if (stamina < 100)
            {
                stamina += .1f;
            }

        }

        HandleMovement();

        if (!isgrounded)
        {
            return;
        }
        if (jumpkey)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jforce, ForceMode.VelocityChange);
            stamina -= 10;
            jumpkey = false;
        }
        issprinting = false;


    }
    private void HandleMouseLook()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * moveSpeed * sprint * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isgrounded = false;
    }

    public void isshooting()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attackzone"))
        {
            isinenemyzone = true;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("attackzone"))
        {
            isinenemyzone = false;

        }
    }
    void fromturrent()
    {
        if (turrentcontroller != null && turrentcontroller.turrenthit)
        {
            playerhealth -= 10;
        }
    }
    
    

    


}


