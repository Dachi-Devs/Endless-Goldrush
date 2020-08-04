using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private PickFrame currentSelection;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private GameObject descText;

    public void UnlockPickaxe()
    {
        currentSelection.UnlockPick();
    }

    public void SetShopSelection(PickFrame selection)
    {
        currentSelection = selection;
        if (currentSelection == null)
        {
            descText.SetActive(true);            
            buyButton.SetActive(false);
        }

        else
        {
            descText.SetActive(false);
            buyButton.SetActive(true);
        }
    }
}
