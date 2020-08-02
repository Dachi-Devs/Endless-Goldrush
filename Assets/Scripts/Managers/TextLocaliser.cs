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

    private void OnEnable()
    {
        LocaliseText();
    }

    private void LanguageSetting_OnLanguageUpdate(object sender, EventArgs e)
    {
        LocaliseText();
    }

    public void LocaliseText()
    {
        textField = GetComponent<Text>();
        string value = Localisation.GetLocalisedValue(key);
        if (value != null)
        {
            value = value.TrimStart(' ', '"'); value = value.Replace("\"", "");
            textField.text = value;
        }
    }
}
