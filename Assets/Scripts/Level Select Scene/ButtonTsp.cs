using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTsp : MonoBehaviour
{
    LevelSelectController levelSelectController;
    Button levelSelectButton;
    private void Awake()
    {
        levelSelectButton = GetComponent<Button>();
        levelSelectController = FindObjectOfType<LevelSelectController>();
    }
    void Start()

    {
        
    }

    void Update()
    {
        levelSelectButton.onClick.AddListener(OnButtonTap);
    }
    public void OnButtonTap()
    {
        StartCoroutine(levelSelectController.LoadToGameScene());
    }
}
