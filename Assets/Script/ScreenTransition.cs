using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    private Text monthText;
    private string monthString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Button monthButton)
    {
        monthText = monthButton.GetComponentInChildren<Text>();
        monthString = monthText.text;
        Debug.Log(monthString);
        PlayerPrefs.SetString("monthString" , monthString);
        PlayerPrefs.Save();
        SceneManager.LoadScene("VerboseScreenScene");
    }

}
