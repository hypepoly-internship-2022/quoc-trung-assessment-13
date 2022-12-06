using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class VotePopupController : Controller
{
    public const string VOTEPOPUP_SCENE_NAME = "VotePopup";

    public override string SceneName()
    {
        return VOTEPOPUP_SCENE_NAME;
    }
}