using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class LevelSelectController : Controller
{
    public const string LEVELSELECT_SCENE_NAME = "LevelSelect";
    public override string SceneName()
    {
        return LEVELSELECT_SCENE_NAME;
    }

    public IEnumerator LoadToGameScene()
    {
        Manager.LoadingAnimation(true);

        yield return new WaitForSeconds(2f);

        Manager.LoadingAnimation(false);

        Manager.Load(GameController.GAME_SCENE_NAME);
    }
    public void OnCloseButtonClick()
    {
        Manager.Load(HomeController.HOME_SCENE_NAME);
    }
   
}