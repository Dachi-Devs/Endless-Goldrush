using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocaliser : MonoBehaviour
{
    private Text textField;
    public string key;

    private void Start()
    {
        textField = GetComponent<Text>();
        string value = Localisation.GetLocalisedValue(key);
        value = value.TrimStart(' ', '"'); value = value.Replace("\"", "");
        textField.text = value;
    }
}
