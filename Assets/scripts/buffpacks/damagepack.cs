using UnityEngine;

public class damagepack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        private bool inintrange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (inintrange == true)
        {
        
            applybuff();
          


        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inintrange = true;

        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inintrange = false;
        }
    }
    private void applybuff()
    {
        PlayerController.gundamage += 11;
        Destroy(gameObject);
    
    }



}
