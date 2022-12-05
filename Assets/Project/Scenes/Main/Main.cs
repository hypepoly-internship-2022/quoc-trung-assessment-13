using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using static LoadingBar;

public class Main : MonoBehaviour
{
    [SerializeField] LoadingBar loadingBar;
    void Start()
    {     
        loadingBar.StartUpdateLoadingBar();     
    }
}
