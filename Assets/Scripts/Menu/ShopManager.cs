using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private PickFrame currentSelection;

    [SerializeField]
    private GameObject buyButton;

    public void UnlockPickaxe()
    {
        currentSelection.UnlockPick();
    }

    public void SetShopSelection(PickFrame selection)
    {
        currentSelection = selection;
        if (currentSelection == null)
            buyButton.SetActive(false);
        else
            buyButton.SetActive(true);
    }
}
