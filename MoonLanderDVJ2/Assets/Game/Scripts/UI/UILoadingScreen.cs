using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingScreen : MonoBehaviourSingleton<UILoadingScreen>
{
    public Text loadingText;
    public GameObject game;
    private GameManager gameMan;
    public override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
        game = GameObject.Find("GameManager");
        gameMan = game.GetComponent<GameManager>();
    }

    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }

    public void Update()
    {
        int loadingVal = (int)(LoaderManager.Get().loadingProgress * 100);
        loadingText.text = "Loading Level "+gameMan.level+" " + loadingVal;
        if (LoaderManager.Get().loadingProgress >= 1)
            SetVisible(false);
    }

}
