using UnityEngine;

public class PickaxeSelection : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO currentSelection;

    public void SetSelection(PickaxeSO pickaxe)
    {
        currentSelection = pickaxe;
        FindObjectOfType<PickaxeProperties>().SetPick(currentSelection);
    }
}
