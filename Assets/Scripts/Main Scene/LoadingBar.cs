using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SS.View;

public class LoadingBar : MonoBehaviour
{
    Slider slider;
    public bool isCompleteLoading;
    [SerializeField] TextMeshProUGUI percentText;
    [SerializeField] TextMeshProUGUI loadingText;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        
    }
    public void StartUpdateLoadingBar()
    {
        StartCoroutine(UpdateLoadingBar());
    }
    
    IEnumerator UpdateLoadingBar()
    {
        for (int i = 0; i <= 100; i++)
        {
            slider.value = i * 0.01f;
            percentText.text = i.ToString() + "%";
            yield return new WaitForSeconds(0.05f);
        }
        CompletedLoading();
        yield return new WaitForSeconds(2f);
        Manager.Load(HomeController.HOME_SCENE_NAME);
        Manager.LoadingSceneName = LoadingController.LOADING_SCENE_NAME;
    }
    void CompletedLoading()
    {
        loadingText.text = "Completed!";
    }
}
