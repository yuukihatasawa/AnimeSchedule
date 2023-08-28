using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private InputField animeTitleInputField;
    [SerializeField] private Text animeTitleText;

    private void Start()
    {
        animeTitleInputField = animeTitleInputField.GetComponent<InputField>();
        animeTitleText = animeTitleText.GetComponent<Text>();
    }

    private void Update()
    {
        
    }

    public void InputTextView()
    {
        animeTitleText.text = animeTitleInputField.text;
    }
}
