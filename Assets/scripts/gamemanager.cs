using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{  
     void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    } public void PlayGame()
    {
       
        SceneManager.LoadScene("SampleScene"); 
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!"); 
        Application.Quit(); 
    }
}
