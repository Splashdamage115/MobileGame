using Esper.ESave;
using UnityEngine;

public class LevelSaveData : MonoBehaviour
{
    public LevelPrefab currentLevel;

    private const string moneyAmtKey = "moneyCurrency";
    public int moneyAmt;

    // save file specific
    private SaveFileSetup saveFileSetup;
    private SaveFile saveFile;
    void Start()
    {
        saveFileSetup = GetComponent<SaveFileSetup>();
        saveFile = saveFileSetup.GetSaveFile();

        initialiseData();
    }

    void initialiseData()
    {
        if (saveFile.HasData(moneyAmtKey))
        {
            moneyAmt = saveFile.GetData<int>(moneyAmtKey);
        }
        else
        {
            moneyAmt = 0;
        }
            Debug.Log("Loaded data.");
    }
    
    public void changeMoneyAmt(int amount)
    {
        moneyAmt = amount;
        saveFile.AddOrUpdateData(moneyAmtKey, moneyAmt);
        saveFile.Save();
    }

    // turn script into singleton
    private static LevelSaveData _instance;

    public static LevelSaveData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<LevelSaveData>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(LevelSaveData).ToString());
                    _instance = singleton.AddComponent<LevelSaveData>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
