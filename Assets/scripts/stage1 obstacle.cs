using UnityEngine;

public class stage1obstacle : MonoBehaviour
{


    
    
    public int obstaclehealth = 600;
    
    public float lastDamageTime = -999f;
    public bool isInHitDetector = false;
    public bool isdestroyed = false;
    public static bool waveend = false;
    

    



    void Start()
    {
        
    }
    void Update()
    {
        damagemech();

        if (!isdestroyed && obstaclehealth <= 0)
        {
            isdestroyed = true;
            
            
           
            death();

        }
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitdetector"))
        {
            isInHitDetector = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hitdetector"))
        {
            isInHitDetector = false;

        }
    }
    void damagemech()
    {
        if (isInHitDetector == true && PlayerController.shooting == true)
        {
            if (Time.time - lastDamageTime >= damagetester.damageCooldown)
            {
                obstaclehealth -= PlayerController.gundamage;
                lastDamageTime = Time.time;
                Debug.Log("Damage dealt. Enemy health: " + obstaclehealth);




            }
        }
    }
    void death()
    {
        waveend = true;
        Destroy(gameObject, 2f);
        
        

           

        
    
    
    }  
}


