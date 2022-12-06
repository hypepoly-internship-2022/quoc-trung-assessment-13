using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using TMPro;

public class HomeController : Controller
{
    public const string HOME_SCENE_NAME = "Home";
    [SerializeField] TextMeshProUGUI heartNumberText;
    int m_heartNumber;
    private void Awake()
    {
        m_heartNumber = 0;
    }
    public override string SceneName()
    {
        return HOME_SCENE_NAME;
    }
    private void Update()
    {
        UpdateHeartNumber();
        
    }
    public void OnVoteButtonTap()
    {
        Manager.Add(VotePopupController.VOTEPOPUP_SCENE_NAME);
    }
    public void OnSettingsButtonTap()
    {
        Manager.Add(SettingsController.SETTINGS_SCENE_NAME);
    }
    public void OnPlayButtonTap()
    {
        if(m_heartNumber <= 0)
        {
            Manager.Add(AdsController.ADS_SCENE_NAME);
            
        }
        else
        {
            Manager.Load(LevelSelectController.LEVELSELECT_SCENE_NAME);
            
        }
    }
    public void UpdateHeartNumber()
    {
        m_heartNumber = PlayerPrefs.GetInt("HeartNumber", 0);
        heartNumberText.text = m_heartNumber.ToString();

    }
 
}