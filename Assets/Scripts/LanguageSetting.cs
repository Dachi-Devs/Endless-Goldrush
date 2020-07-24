using System;
using UnityEngine;

public class LanguageSetting : MonoBehaviour
{
    public event EventHandler OnLanguageUpdate; 

    public void SetLanguage(string languageToSet)
    {
        PlayerPrefs.SetString("Language", languageToSet);
        Localisation.language = (Localisation.Language)Enum.Parse(typeof(Localisation.Language), PlayerPrefs.GetString("Language"));
        OnLanguageUpdate?.Invoke(this, EventArgs.Empty);
    }
}
