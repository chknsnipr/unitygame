using TMPro;
using UnityEngine;


public class UIelements : MonoBehaviour
{
    public TextMeshProUGUI healthtext;

    public TextMeshProUGUI staminaText;  
    public PlayerController player;     

    void Update()
    {
       
           
        
        if (player != null)
            {
                healthtext.text = "Health: " + PlayerController.playerhealth.ToString();
                staminaText.text = "Stamina: " + player.stamina.ToString();
            }
        }
}

