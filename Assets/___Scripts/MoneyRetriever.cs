using System;
using TMPro;
using UnityEngine;

public class MoneyRetriever : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = LevelSaveData.Instance.moneyAmt.ToString();
    }
}
