using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILandingScreen : MonoBehaviourSingleton<UILandingScreen>
{
    public Text points;
    public GameObject game;
    private GameManager gameMan;

    void Start()
    {
        game = GameObject.Find("GameManager");
        gameMan = game.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + Mathf.RoundToInt(gameMan.points);
    }
}
