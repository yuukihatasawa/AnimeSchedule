using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private Dropdown dropdownMonth;
    [SerializeField] private Dropdown dropdownDay;
    [SerializeField] private InputField animeTitleInputField;
    [SerializeField] private Text animeText;

    List<string> jsonDataList = new List<string>();
    private string jsonString;
    


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
        Save();
    }

    private void Save()
    {
        saveDataJson.month = dropdownMonth.options[dropdownMonth.value].text;
        saveDataJson.day = dropdownDay.options[dropdownDay.value].text;
        saveDataJson.animeTitle = animeTitleInputField.text;
        jsonString = JsonUtility.ToJson(saveDataJson);
        File.WriteAllText($"Assets/Resources/AnimeData.json", jsonString);
        Debug.Log("1" + jsonString);
        jsonDataList.Add(jsonString);

        foreach (var json in jsonDataList)
        {
            Debug.Log("セーブしたよ" + json);
            animeText.text = json;
        }
    }

    private void Load()
    {
        TextAsset jsonLoad = Resources.Load<TextAsset>("AnimeData");
        SaveDataJson animeData = JsonUtility.FromJson<SaveDataJson>(jsonLoad.text);
        Debug.Log("ロードしたよ！！");
    }
}


