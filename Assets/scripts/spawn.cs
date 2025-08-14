using System.Collections;
using UnityEngine;



public class spawn : MonoBehaviour
{
    public static float spawntime = 30f;

    public static int tcount = 0;
    public GameObject enemyprefab;

    public static bool levelup1;
    public static bool levelup2;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       StartCoroutine(spawnEnemy());
    }
    void Update()
 
    {
        if (tcount == 1 && !levelup1)
        {
            spawntime = 12f;
           
            levelup1 = true;

            StopAllCoroutines();
            StartCoroutine(spawnEnemy());
        }

        if (tcount == 2 && !levelup2)
        {
            spawntime = 5f;
           
            levelup2 = true;

            StopAllCoroutines();
            StartCoroutine(spawnEnemy());
        }
    }


    // Update is called once per frame
    IEnumerator spawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyprefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawntime);
        }
    }
}
