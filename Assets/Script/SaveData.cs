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
        dropdownMonth = GameObject.Find("Month").GetComponent<Dropdown>();
        dropdownDay = GameObject.Find("Day").GetComponent<Dropdown>();
        animeTitleInputField = GameObject.Find("TitleEntry").GetComponent<InputField>();
    }

    public void OnClick()
    {
        saveDataJson.month = dropdownMonth.options[dropdownMonth.value].text;
        saveDataJson.day = dropdownDay.options[dropdownDay.value].text;
        saveDataJson.animeTitle = animeTitleInputField.text;
        string jsonStrig = JsonUtility.ToJson(saveDataJson);
        Debug.Log(jsonStrig);
    }
}


