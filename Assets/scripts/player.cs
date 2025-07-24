using Unity.VisualScripting;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Mouse Look Settings")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float maxLookAngle = 90f;
    [SerializeField] private float jforce;
    bool isgrounded;

    bool jumpkey;

    private Rigidbody rb;
    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;

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
    }

    private void FixedUpdate()

    {
       
        HandleMovement();
        if (!isgrounded)
        {
            return;
        }
        if (jumpkey)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jforce, ForceMode.VelocityChange);
                jumpkey = false;
            }
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
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isgrounded = false;
    }

}


