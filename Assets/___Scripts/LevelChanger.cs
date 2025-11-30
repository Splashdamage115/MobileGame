using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    [System.Serializable]
    public struct levelObject
    {
        public string name;
        public Color color;
        public GameObject levelPrefab;
    }
    public levelObject[] level;
    private int levelDifficulty;

    private GameObject currentPrefab;

    public TextMeshProUGUI levelDifficultyText;
    public Button levelDifficultyButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelDifficulty = 0;
        ChangeElement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeElement()
    {
        currentPrefab = Instantiate(level[levelDifficulty].levelPrefab);
        levelDifficultyText.text = level[levelDifficulty].name;
        var colors = levelDifficultyButton.colors;
        colors.normalColor = level[levelDifficulty].color;
        colors.selectedColor = level[levelDifficulty].color;
        levelDifficultyButton.colors = colors;
    }

    public void changeDifficulty()
    {
        levelDifficulty++;

        if(levelDifficulty >= level.Length) 
        {
            levelDifficulty = 0;
        }
        Destroy(currentPrefab);
        ChangeElement();
    }
}
