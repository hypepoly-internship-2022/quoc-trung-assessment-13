using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;


public class GameController : Controller
{
    public const string GAME_SCENE_NAME = "Game";

    public override string SceneName()
    {
        return GAME_SCENE_NAME;
    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        Manager.Add(PauseController.PAUSE_SCENE_NAME);
    }
}