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

    private void OnEnable()
    {
        SetDescKeys(pickSelect.currentPickaxe.pickNameKey, pickSelect.currentPickaxe.pickDescKey);
    }

    public void SetDescKeys(string key, string desc)
    {
        pickaxeName.key = key;
        pickaxeName.LocaliseText();
        pickaxeDesc.key = desc;
        pickaxeDesc.LocaliseText();
    }
}
