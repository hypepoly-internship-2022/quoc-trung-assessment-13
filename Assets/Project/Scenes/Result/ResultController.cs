using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using TMPro;

public class ResultController : Controller
{
    public const string RESULT_SCENE_NAME = "Result";
    int starNumber;
    [SerializeField] GameObject stars;
    [SerializeField] TextMeshProUGUI ribbonText;
    [SerializeField] TextMeshProUGUI congrateText;
    [SerializeField] TextMeshProUGUI scoreText;

    public override string SceneName()
    {
        return RESULT_SCENE_NAME;
    }
    public void OnHomeButtonClick()
    {
        Manager.Load(HomeController.HOME_SCENE_NAME);
    }
    public void OnVoteButtonClick()
    {
        Manager.Add(VotePopupController.VOTEPOPUP_SCENE_NAME);
    }
    public override void OnActive(object data = null)
    {
        if (data != null)
        {
            starNumber = int.Parse(data.ToString());
        }
        StartGenerateStar(starNumber);
    }
    void StartGenerateStar(int starNumber)
    {
        if(starNumber == 0)
        {
            SetUpText();
        }
        for (int i = 0; i < starNumber; i++)
        {
           stars.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    void SetUpText()
    {
        ribbonText.text = "You Lose";
        scoreText.text = "0";
        congrateText.text = "Better Luck Next Time";
    }
}