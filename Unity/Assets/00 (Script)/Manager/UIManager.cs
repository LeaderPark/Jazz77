using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public CanvasGroup gameover;
    public void gameoverUI()
    {
        gameover.alpha += Time.deltaTime;
        if(gameover.alpha >= 1)
        {
            Time.timeScale = 0;
        }
    }
}
