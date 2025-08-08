using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class damagetester : MonoBehaviour
{


    public int enemyhealth = 100;
    public static float damageCooldown = 0.5f; // time between each damage hit in seconds
    private float lastDamageTime = -999f;
    public bool isInHitDetector = false;
    public bool isdead = false;

    public bool isinrange = false;

    

    private PlayerController player;

    private bool isDamageCoroutineRunning;

    public int enemydamage = 20;

    private float attackcooldown;

    public bool isattacking = false;

    private Animator anim;








    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()


    {
        attackcooldown += Time.deltaTime;
        if (attackcooldown > 2f)
        {
            attack();
            attackcooldown -= Time.deltaTime;
        }
        damagemech();

        if (!isdead && enemyhealth <= 0)
        {
            isdead = true;
            //anim.SetBool("isdead", true);


            death();

        }
        if (stage1obstacle.waveend == true)
        {
            isdead = true;
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
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                enemyhealth -= PlayerController.gundamage;
                lastDamageTime = Time.time;
                Debug.Log("Damage dealt. Enemy health: " + enemyhealth);




            }
        }
    }
    void death()
    {
        Destroy(gameObject, 4f);
        Debug.Log(isdead);







    }
    void attack()
    {
        if (isinrange == true && !isDamageCoroutineRunning)


        {


            isattacking = true;
            isDamageCoroutineRunning = true;
            StartCoroutine(DelayedDamage());




        }
    }

    IEnumerator DelayedDamage()
    {
        yield return new WaitForSeconds(2f);
        ApplyDamage();
    }
    void ApplyDamage()
    {
        PlayerController.playerhealth -= enemydamage;
        isDamageCoroutineRunning = false;
        isattacking = false;
    } 
        
}
