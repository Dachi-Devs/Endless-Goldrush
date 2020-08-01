using UnityEngine;
using UnityEngine.UI;

public class LoadRecord : MonoBehaviour
{
    [SerializeField]
    private Text statNumber;

    [SerializeField]
    private TextLocaliser statName;

    public void LoadStat(string statToLoad)
    {
        statName.key = (statToLoad + "_TEXT").ToUpper(); ;
        statNumber.text = PlayerPrefs.GetInt(statToLoad).ToString();
    }
}
