using UnityEngine;

public class player_mechanics : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerspeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Capital "Vertical"
        rb.MovePosition(rb.position + movement * playerspeed * Time.fixedDeltaTime); // Multiply by deltaTime for consistent movement
    }
}
