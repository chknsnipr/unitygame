using TMPro;
using UnityEngine;


public class UIelements : MonoBehaviour
{
    public TextMeshProUGUI healthtext;

    public TextMeshProUGUI staminaText;

    public TextMeshProUGUI damage; 
    public PlayerController player;

    void Update()
    {



        if (player != null)
        {
            healthtext.text = "Health: " + PlayerController.playerhealth.ToString();
            staminaText.text = "Stamina: " + Mathf.RoundToInt(player.stamina).ToString();
            damage.text = "damage: " + PlayerController.gundamage.ToString();
        }
        else
        {   
        }
    }
}

