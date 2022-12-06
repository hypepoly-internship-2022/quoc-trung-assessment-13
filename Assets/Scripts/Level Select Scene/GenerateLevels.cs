using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenerateLevels : MonoBehaviour
{
    [SerializeField] Button activeButtonPrefab;
    [SerializeField] Button deactiveButtonPrefab;
    [SerializeField] int levelToGenerate;
    [SerializeField] Transform parent;
    
    private void Awake()
    {

    }
    void Start()
    {
        StartGenerateButtons();
    }

    void Update()
    {
        
    }
    void StartGenerateButtons()
    {

        for(int i = 1; i <= levelToGenerate; i++)
        {
            if (i == 1)
            {
                GenerateButton(i, true);
            }
            else
            {
                GenerateButton(i, false);
            }
        }
    }
    void GenerateButton(int index, bool isActive)
    {
        GameObject levelButton;
        TextMeshProUGUI levelIndex;
        if (isActive)
        {
            levelButton = Instantiate(activeButtonPrefab, parent).gameObject;
        }
        else
        {
            levelButton = Instantiate(deactiveButtonPrefab, parent).gameObject;
        }
        levelIndex = levelButton.GetComponentInChildren<TextMeshProUGUI>();
        levelIndex.text = index.ToString();
    }
}
