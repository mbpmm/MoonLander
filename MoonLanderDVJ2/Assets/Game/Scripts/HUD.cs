using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Text points;
    public Text fuel;
    public Text velX;
    public Text velY;
    public Text time;
    public GameObject player;
    public GameObject gameManager;
    public Canvas pauseMenu;
    private PlayerController playerData;
    private GameManager gameMan;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        playerData = player.GetComponent<PlayerController>();
        gameMan = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fuel.text = "Fuel: " + Mathf.RoundToInt(playerData.fuel);
        velX.text = "Horizontal speed: " + Math.Round(playerData.velHorizontal,3)*10;
        velY.text = "Vertical speed: " + Math.Round(playerData.velVertical,3)*10;
        time.text = "Time: " + Mathf.RoundToInt(Time.time) +" sec.";
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("IntroScene");
    }
}