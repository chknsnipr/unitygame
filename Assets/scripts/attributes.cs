using UnityEngine;
//PersonProperties
public class attributes : MonoBehaviour
{
    public static int globalvar=10;

    public int health;
    public int damage;
    public void damagemech(int amount)
    {
        health -= amount;
    }
    public void dealdamage(GameObject target)
    {
        var atm = target.GetComponent<attributes>();
        if (atm != null)
        {
            atm.damagemech(damage);
        }  
    }
}
