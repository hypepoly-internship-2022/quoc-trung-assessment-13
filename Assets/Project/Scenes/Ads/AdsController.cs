using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class AdsController : Controller
{
    public const string ADS_SCENE_NAME = "Ads";
    public override string SceneName()
    {
        return ADS_SCENE_NAME;
    }
    public void OnWatchButtonClick()
    {
        PlayerPrefs.SetInt("HeartNumber", 5);
    }
}