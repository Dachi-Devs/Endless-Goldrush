﻿using System.Collections.Generic;
using UnityEngine;

public class Localisation : MonoBehaviour
{
    public enum Language
    { 
        English,
        German
    }

    public static Language language = Language.German;

    private static Dictionary<string, string> localisedENG;
    private static Dictionary<string, string> localisedGER;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();

        csvLoader.LoadCSV();

        localisedENG = csvLoader.GetDictionaryValues("eng");
        localisedGER = csvLoader.GetDictionaryValues("ger");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit) { Init(); }

        string value = key;

        switch (language)
        {
            case Language.English:
                localisedENG.TryGetValue(key, out value);
                break;
            case Language.German:
                localisedGER.TryGetValue(key, out value);
                break;
        }
        return value;
    }
}
