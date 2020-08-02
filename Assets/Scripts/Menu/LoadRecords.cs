using UnityEngine;

public class LoadRecords : MonoBehaviour
{
    [SerializeField]
    private string[] statKeys;

    [SerializeField]
    private GameObject recordPrefab;

    private void OnEnable()
    {
        if (GetComponentsInChildren<LoadRecord>().Length < 1)
        {
            for (int i = 0; i < statKeys.Length; i++)
            {
                CreateRecordList();
            }
        }
        UpdateStats();
    }

    private void CreateRecordList()
    {
         Instantiate(recordPrefab, transform);
    }

    private void UpdateStats()
    {
        LoadRecord[] stats = GetComponentsInChildren<LoadRecord>();
        int i = 0;
        foreach (LoadRecord stat in stats)
        {
            stat.LoadStat(statKeys[i]);
            i++;
        }
    }
}
