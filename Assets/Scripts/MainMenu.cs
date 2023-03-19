using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
<<<<<<< Updated upstream
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
        SceneManager.LoadScene("Tanman");
>>>>>>> Stashed changes
    }
    public void QuitGame(){
        Application.Quit();
    }
}
