using System;
using UnityEngine;
using UnityEngine.UI;

public class TextLocaliser : MonoBehaviour
{
    private Text textField;
    public string key;

    private void Start()
    {
        LocaliseText();
        LanguageSetting lang = FindObjectOfType<LanguageSetting>();
        if (lang != null)
            lang.OnLanguageUpdate += LanguageSetting_OnLanguageUpdate;
    }

    private void LanguageSetting_OnLanguageUpdate(object sender, EventArgs e)
    {
        LocaliseText();
    }

    public void LocaliseText()
    {
        textField = GetComponent<Text>();
        string value = Localisation.GetLocalisedValue(key);
        value = value.TrimStart(' ', '"'); value = value.Replace("\"", "");
        textField.text = value;
    }
}
