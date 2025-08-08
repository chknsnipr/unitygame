using UnityEngine;

public class base_enemytrans : MonoBehaviour
{
    private Animator anim;
    damagetester dmgtest;
    

    void Start()

    {
        dmgtest = GetComponentInParent<damagetester>();
    
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("isattacking", dmgtest.isattacking);
        anim.SetBool("isdead", dmgtest.isdead); // Access shared static variable
    }
}