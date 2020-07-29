using System;
using UnityEngine;

public class ShopDescription : MonoBehaviour
{
    [SerializeField]
    private TextLocaliser pickaxeName;

    [SerializeField]
    private TextLocaliser pickaxeDesc;

    [SerializeField]
    private PickSelectSO pickSelect;


    void Start()
    {
        FindObjectOfType<PickaxeSelection>().OnPickSelect += PickaxeSelection_OnPickSelect;
        SetDescKeys();
    }

    private void PickaxeSelection_OnPickSelect(object sender, EventArgs e)
    {
        SetDescKeys();
    }

    private void SetDescKeys()
    {
        pickaxeName.key = FindObjectOfType<PickaxeSelection>().pickSelect.currentPickaxe.pickNameKey;
        pickaxeName.LocaliseText();
        pickaxeDesc.key = FindObjectOfType<PickaxeSelection>().pickSelect.currentPickaxe.pickDescKey;
        pickaxeDesc.LocaliseText();
    }
}
