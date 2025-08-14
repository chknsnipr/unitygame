using Mythmatic.TurretSystem;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerController : MonoBehaviour
{
    public static bool pdeath = false;
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
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;
    public float shakeInterval = 0.3f;
    private float shakeTimer = 0f;

    private bool applied1 = false;
    private bool applied2 = false;


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
        damagemodifier();
        playerdeath();




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
                    stamina -= .5f;
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
        if (Input.GetMouseButton(0))
        {
            shooting = true;

            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                StartCoroutine(ScreenShake());
                shakeTimer = shakeInterval;
            }

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
    private System.Collections.IEnumerator ScreenShake()
    {
        Vector3 originalPos = cameraTransform.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            cameraTransform.transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.transform.localPosition = originalPos;
    }
    void damagemodifier()
    {
        if (!applied1 && spawn.levelup1 == true)
        {
            gundamage -= gundamage / 4;
            applied1 = true;


        }
        if (!applied2 && spawn.levelup2 == true)
        {
            gundamage -= gundamage / 4;
            applied2 = true;
        }
    }
    void playerdeath()
    {
        if (playerhealth <= 0 && !pdeath)

        {
            SceneManager.LoadScene("mainmenu");
            pdeath = true;


        }
    }
    
    

    


}


