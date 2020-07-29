using UnityEngine;

public class LoadRecords : MonoBehaviour
{
    [SerializeField]
    private string[] statKeys;

    [SerializeField]
    private GameObject recordPrefab;

    private void Start()
    {
        for (int i = 0; i < statKeys.Length; i++)
        {
            CreateRecordList();
        }
    }

    private void OnEnable()
    {
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
