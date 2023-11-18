using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private InputField inputFieldMonth;
    [SerializeField] private Dropdown dropdownDay;
    [SerializeField] private InputField animeTitleInputField;
    [SerializeField] private Text animeText;

    private string jsonDataPass = "Assets/Resources/AnimeData.json";
    private string jsonString;

    /// <summary>
    /// 「JsonUtility」を使用して構造体をJson形式にシリアライズする
    /// </summary>
    [System.Serializable]
    public class SaveDataJson
    {
        public string month;
        public string day;
        public string animeTitle;
    }

    /// <summary>
    /// 構造体を初期化
    /// </summary>
    public SaveDataJson saveDataJson = new SaveDataJson();

    private void Start()
    {
        inputFieldMonth = inputFieldMonth.GetComponent<InputField>();
        dropdownDay = dropdownDay.GetComponent<Dropdown>();
        animeTitleInputField = animeTitleInputField.GetComponent<InputField>();
        animeText = animeText.GetComponent<Text>();
    }

    /// <summary>
    /// JSONファイルに最初に書き込む
    /// </summary>
    public void CreateJsonFile()
    {
        saveDataJson.month = inputFieldMonth.text;
        saveDataJson.day = dropdownDay.options[dropdownDay.value].text;
        saveDataJson.animeTitle = animeTitleInputField.text;
        jsonString = JsonUtility.ToJson(saveDataJson , true);
        File.WriteAllText(jsonDataPass, jsonString);
        SaveDataJson fromJson = JsonUtility.FromJson<SaveDataJson>(jsonString);
        Debug.Log($"Month : {fromJson.month}");
    }

    /// <summary>
    /// JSONファイルに追記で書き込む
    /// </summary>
    public void AppendToJsonFile()
    {
        saveDataJson.month = inputFieldMonth.text;
        saveDataJson.day = dropdownDay.options[dropdownDay.value].text;
        saveDataJson.animeTitle = animeTitleInputField.text;
        jsonString = JsonUtility.ToJson(saveDataJson, true);
        Debug.Log("追記したよ" + jsonString);
        File.AppendAllText(jsonDataPass , jsonString);
        animeText.text = jsonString;
    }

    //public void Load()
    //{
    //    TextAsset jsonLoad = Resources.Load<TextAsset>("AnimeData");
    //    SaveDataJson animeData = JsonUtility.FromJson<SaveDataJson>(jsonLoad.text);
    //    Debug.Log("ロードしたよ！！");
    //}
}


