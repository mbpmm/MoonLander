using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public float points;
    public GameObject player;
    public GameObject landingScreen;
    public Text winText;
    public Text loseText;
    public Button next;
    public int level;
    private bool gameOver;
    private PlayerController playerCont;
    private float pointsLanded=500f;
    // Start is called before the first frame update
    void Start()
    {
        landingScreen = GameObject.Find("LandingScreen");
        player = GameObject.Find("Player");
        playerCont = player.GetComponent<PlayerController>();
        level = 1;
        landingScreen.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player==null)
        {
            player = GameObject.Find("Player");
            playerCont = player.GetComponent<PlayerController>();
        }

        if (playerCont.onGround)
        {
            points += pointsLanded + playerCont.fuel / 10;
            landingScreen.SetActive(true);
            winText.gameObject.SetActive(true);
            next.GetComponentInChildren<Text>().text = "Next";
            next.onClick.AddListener(NextLvl);
            playerCont.onGround = false;
        }
        
        if (playerCont.isDestroyed)
        {
            landingScreen.SetActive(true);
            loseText.gameObject.SetActive(true);
            next.GetComponentInChildren<Text>().text = "try again";
            next.onClick.AddListener(TryAgain);
            playerCont.isDestroyed = false;
        }
        
    }


    public void NextLvl()
    {
        level++;
        LoaderManager.Get().LoadScene("GameScene");
        UILoadingScreen.Get().SetVisible(true);
        landingScreen.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        next.onClick.RemoveAllListeners();
    }

    public void TryAgain()
    {
        next.onClick.RemoveAllListeners();
        SceneManager.LoadScene("GameScene");
        level = 1;
        landingScreen.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        points = 0;
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene("IntroScene");
        Destroy(gameObject);
        Destroy(landingScreen);
    }
}
