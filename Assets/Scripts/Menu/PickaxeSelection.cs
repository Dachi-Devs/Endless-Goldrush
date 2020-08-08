using System;
using UnityEngine;
public class PickaxeSelection : MonoBehaviour
{
    public PickSelectSO pickSelect;

    public event EventHandler OnPickSelect;

    private void Start()
    {
        if (PlayerPrefs.GetString("StartPick") == null || PlayerPrefs.GetInt(PlayerPrefs.GetString("StartPick")) == 0)
            PlayerPrefs.SetString("StartPick", "CopperPickaxe");
        PickaxeSO startPick = Resources.Load<PickaxeSO>("Data/Pickaxes/" + PlayerPrefs.GetString("StartPick"));
        SetSelection(startPick);
    }

    public void SetSelection(PickaxeSO pickaxe)
    {
        pickSelect.currentPickaxe = pickaxe;
        PlayerPrefs.SetString("StartPick", pickaxe.name);
        OnPickSelect?.Invoke(this, EventArgs.Empty);
    }

    public PickaxeSO GetSelection() => pickSelect.currentPickaxe;
}
