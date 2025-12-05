using UnityEngine;

enum Level_Difficulty
{
    Easy, Medium, Hard
}

[CreateAssetMenu]
public class LevelPrefab : ScriptableObject
{
    public string levelname;
    public Color color;
    public GameObject levelPrefab;
    public int recommendedLevel;
}
