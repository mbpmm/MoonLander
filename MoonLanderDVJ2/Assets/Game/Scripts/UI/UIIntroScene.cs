using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIIntroScene : MonoBehaviour
{
    public Button play;
    public Button quit;
    public Canvas credits;
    // Start is called before the first frame update
    void Start()
    {
        credits.gameObject.SetActive(false);
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void GoToMenu()
    {
        credits.gameObject.SetActive(false);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
