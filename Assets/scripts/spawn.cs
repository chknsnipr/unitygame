using System.Collections;
using UnityEngine;



public class spawn : MonoBehaviour
{
    public static float spawntime = 30f;
    public GameObject enemyprefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    IEnumerator spawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyprefab, new Vector3(-15, 2.08f, 3.97f), Quaternion.identity);
            yield return new WaitForSeconds(spawntime);
        }
    }
}
