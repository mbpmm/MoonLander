using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text points;
    public Text fuel;
    public Text velX;
    public Text velY;
    public Text time;
    public GameObject player;
    public GameObject gameManager;
    private PlayerController playerData;
    private GameManager gameMan;
    // Start is called before the first frame update
    void Start()
    {
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
}