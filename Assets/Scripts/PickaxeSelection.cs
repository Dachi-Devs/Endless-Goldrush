using System;
using UnityEngine;
public class PickaxeSelection : MonoBehaviour
{
    public PickSelectSO pickSelect;

    public event EventHandler OnPickSelect;

    private void Start()
    {
        PickaxeSO startPick = Resources.Load<PickaxeSO>("Data/Pickaxes/" + PlayerPrefs.GetString("StartPick"));
        SetSelection(startPick);
    }

    public void SetSelection(PickaxeSO pickaxe)
    {
        pickSelect.currentPickaxe = pickaxe;
        OnPickSelect?.Invoke(this, EventArgs.Empty);
        PlayerPrefs.SetString("StartPick", pickaxe.name);
    }
}
