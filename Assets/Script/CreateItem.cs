using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateItem : MonoBehaviour
{
    private ItemPrefab itemPrefab;
    private SaveDataManager saveDataManeger;
    private bool firstFlag = true;
    //private RectTransform rectTransform;

    private void Start()
    {
        saveDataManeger = GameObject.Find("Button").GetComponent<SaveDataManager>();
        itemPrefab = GameObject.Find("Item").GetComponent<ItemPrefab>();
    }

    private void Update()
    {

    }

    /// <summary>
    /// 追加ボタンを押下したら、JSONデータ形式でコンソール上に表示される
    /// </summary>
    public void OnClick()
    {
        itemPrefab.CreateItem();
        if (firstFlag)
        {
            saveDataManeger.CreateJsonFile();
            firstFlag = false;
            Debug.Log("1、作成");

        }
        else
        {
            ////生成されたitemのprefabの座標を取得。
            //rectTransform = itemPrefab.GetComponent<RectTransform>();
            ////pos変数に生成されたitemのprefabのpositionのy座標を−100させる
            //Vector2 itemPrefabPos = rectTransform.position;
            //itemPrefabPos.y -= 100;
            //rectTransform.position = itemPrefabPos;
            saveDataManeger.AppendToJsonFile();
            Debug.Log("2、追記");
        }
    }

}
