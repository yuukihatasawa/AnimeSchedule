using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropDownManager : MonoBehaviour
{
    //[SerializeField] private Dropdown dropdownMonth;
    [SerializeField] private InputField inputFieldMonth;
    [SerializeField] private Dropdown dropdownDay;

    private string getStringMonth;

    void Start()
    {
        if (inputFieldMonth)
        {
            getStringMonth = PlayerPrefs.GetString("monthString" , "月");
            inputFieldMonth.text = getStringMonth;
        }


        if (dropdownDay)
        {
            //ここでクリアにする
            dropdownDay.ClearOptions();

            List<string> dayList = new List<string>();
            for (int i = 0; i <= 31; i++)
            {
                if (i == 0)
                {
                    dayList.Add("日");
                }
                else
                {
                    dayList.Add(i.ToString() + "日");
                }
            }
            dropdownDay.AddOptions(dayList);
            dropdownDay.value = 0;
        }
        
    }
}
