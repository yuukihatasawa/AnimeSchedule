using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

//プレハブをインスタンス化するクラスで位置を指定するのが良いと思います。
//現在はプレハブが自分で位置を設定していると思うのですが、プレハブを作成するクラスで
//何件データがあるのかを保持して、インスタンス化する度に位置を設定するみたいな感じがわかりやすい



public class ItemPrefab : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject scrollViewContent;

    private GameObject itemPrefab;
    List<GameObject> itemsList = new List<GameObject>();


    private void Start()
    {
    }

    /// <summary>
    /// インスタンス化させてリストに保存
    /// </summary>
    public void CreateItem()
    {

        int number = 0;
        if (number < itemsList.Count)
        {
            Debug.Log(itemsList.Count + "個目b");
            //itemsListの最後の要素を取得
            GameObject last = itemsList[itemsList.Count - 1];
            //最後の要素の位置からy軸が−100の位置になるように設定する。
            RectTransform pos = last.GetComponent<RectTransform>();
            Vector2 lastPos = pos.position;
            lastPos.y += -100;
            pos.position = lastPos;
            itemsList.Add(itemPrefab);
            Debug.Log(itemsList.Count + "個目c");
        }
        else
        {
            itemPrefab = Instantiate(item);
            itemsList.Add(itemPrefab);
            Debug.Log(itemsList.Count + "個目a");
        }


        itemPrefab.transform.SetParent(scrollViewContent.transform, false);

    }

}
