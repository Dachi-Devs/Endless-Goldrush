using System;
using UnityEngine;

public class PickaxeProperties : MonoBehaviour
{
    [SerializeField]
    private PickSelectSO pickaxe;


    void OnEnable()
    {
        PickaxeSelection ps = FindObjectOfType<PickaxeSelection>();
        if (ps != null)
            ps.OnPickSelect += PickaxeSelection_OnPickSelect;
        UpdatePick();
    }

    private void PickaxeSelection_OnPickSelect(object sender, EventArgs e)
    {
        UpdatePick();
    }

    private void UpdatePick()
    {
        GetComponent<SpriteRenderer>().sprite = pickaxe.currentPickaxe.sprite;
    }
}
