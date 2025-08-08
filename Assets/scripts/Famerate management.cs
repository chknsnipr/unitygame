using UnityEngine;

public class Fameratemanagement : MonoBehaviour
{
   
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
        Screen.SetResolution(540, 400, false);
    }


 
   
}
