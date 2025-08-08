using UnityEngine;



public class attackzone : MonoBehaviour
{
    private damagetester parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GetComponentInParent<damagetester>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.isinrange = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parent.isinrange = false;

        }
    }
}
