using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private Dropdown dropdownMonth;
    [SerializeField] private Dropdown dropdownDay;
    [SerializeField] private InputField animeTitleInputField;
    [SerializeField] private Text animeText;

    List<string> jsonDataList = new List<string>();
    private string jsonDataPass = "Assets/Resources/AnimeData.json";

    private string jsonString;
    private bool firstFlag = true;
    


    //「JsonUtility」を使用して構造体をJson形式にシリアライズする
    [System.Serializable]
    public class SaveDataJson
    {
        public string month;
        public string day;
        public string animeTitle;
    }

    //構造体を初期化
    public SaveDataJson saveDataJson = new SaveDataJson();

    private void Start()
    {
        dropdownMonth = dropdownMonth.GetComponent<Dropdown>();
        dropdownDay = dropdownDay.GetComponent<Dropdown>();
        animeTitleInputField = animeTitleInputField.GetComponent<InputField>();
        animeText = animeText.GetComponent<Text>();
    }

    //追加ボタンを押下したら、JSONデータ形式でコンソール上に表示される
    public void OnClick()
    {
        saveDataJson.month = dropdownMonth.options[dropdownMonth.value].text;
        saveDataJson.day = dropdownDay.options[dropdownDay.value].text;
        saveDataJson.animeTitle = animeTitleInputField.text;
        if (firstFlag)
        {
            Debug.Log("1、作成");
            CreateJsonFile();
            firstFlag = false;
        }
        else
        {
            Debug.Log("2、追記");
            AppendToJsonFile();
        }
    }

    private void CreateJsonFile()
    {
        jsonString = JsonUtility.ToJson(saveDataJson , true);
        File.WriteAllText(jsonDataPass, jsonString);
    }

    private void AppendToJsonFile()
    {
        jsonString = JsonUtility.ToJson(saveDataJson, true);
        Debug.Log("追記したよ" + jsonString);
        File.AppendAllText(jsonDataPass , jsonString);
        animeText.text = jsonString;
    }

    private void Load()
    {
        TextAsset jsonLoad = Resources.Load<TextAsset>("AnimeData");
        SaveDataJson animeData = JsonUtility.FromJson<SaveDataJson>(jsonLoad.text);
        Debug.Log("ロードしたよ！！");
    }
}


