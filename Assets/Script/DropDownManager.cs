using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropDownManager : MonoBehaviour
{
    [SerializeField] private Dropdown dropdownMonth;
    [SerializeField] private Dropdown dropdownDay;


    void Start()
    {
        if (dropdownMonth) {
            //Debug.Log(dropdownMonth);
            dropdownMonth.ClearOptions(); //現在の要素をクリアする

            List<string> monthList = new List<string>();
            for (int i = 0; i <= 12; i++)
            {
                if (i == 0)
                {
                    monthList.Add("月");
                }
                else
                {
                    monthList.Add(i.ToString() + "月");
                }
            }
            dropdownMonth.AddOptions(monthList);
            dropdownMonth.value = 0;
        }

        if (dropdownDay)
        {
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
