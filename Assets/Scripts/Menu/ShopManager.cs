using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private PickFrame currentSelection;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private GameObject premiumButton;

    [SerializeField]
    private GameObject descText;

    [SerializeField]
    private Text goldText;

    [SerializeField]
    private int goldAmount;

    [SerializeField]
    private PickFrame[] premiumPicks;

    private void Start()
    {
        PickFrame[] frames = GetComponentsInChildren<PickFrame>();
        PickaxeSO currentSelection = FindObjectOfType<PickaxeSelection>().GetSelection();

        if (PlayerPrefs.GetInt("CopperPickaxe") == 0)
            PlayerPrefs.SetInt("CopperPickaxe", 1);

        foreach (PickFrame frame in frames)
        {
            if (PlayerPrefs.GetInt(frame.GetName()) == 1)
            {
                frame.UnlockPick();
            }
        }
        FindObjectOfType<PickaxeSelection>().SetSelection(currentSelection);
    }

    private void OnEnable()
    {
        goldAmount = PlayerPrefs.GetInt("CurrentGold");
        goldText.text = goldAmount.ToString();
    }

    public void UnlockPickaxe()
    {
        int selectCost = currentSelection.GetCost();
        if (goldAmount >= selectCost)
        {
            goldAmount -= selectCost;
            PlayerPrefs.SetInt("CurrentGold", goldAmount);
            goldText.text = goldAmount.ToString();        
            PlayerPrefs.SetInt(currentSelection.GetName(), currentSelection.GetIsLocked() ? 1 : 0);            
            currentSelection.UnlockPick();
        }

    }

    public void SetShopSelection(PickFrame selection)
    {
        premiumButton.SetActive(false);
        currentSelection = selection;
        if (currentSelection == null)
        {
            descText.SetActive(true);            
            buyButton.SetActive(false);
        }

        else
        {
            if (premiumPicks.Contains(currentSelection))
            {
                descText.SetActive(false);
                premiumButton.SetActive(true);
            }

            else
            {
                descText.SetActive(false);
                buyButton.SetActive(true);
                buyButton.GetComponentInChildren<Text>().text = currentSelection.GetCost().ToString();
            }
        }
    }

    private void PurchasePickPack()
    {
        foreach (PickFrame frame in premiumPicks)
        {
            PlayerPrefs.SetInt(frame.GetName(), 1);
            frame.UnlockPick();
        }
    }

    public void OnPurchaseComplete(Product product)
    {
        PurchasePickPack();

        premiumButton.SetActive(false);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product " + product.definition.id + " failed due to " + reason);
    }
}
