using System;
using UnityEngine;
public class PickaxeSelection : MonoBehaviour
{
    public PickSelectSO pickSelect;

    public event EventHandler OnPickSelect;

    public void SetSelection(PickaxeSO pickaxe)
    {
        pickSelect.currentPickaxe = pickaxe;
        OnPickSelect?.Invoke(this, EventArgs.Empty);
    }
}
