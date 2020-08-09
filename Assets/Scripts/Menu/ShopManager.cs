using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.Security;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, IStoreListener
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

    IStoreController storeController;
    IExtensionProvider extensionProvider;

    public static string googlePlayPremium = "com.dachidevs.endlessgoldrush.premium";

    private void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }

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

    public void InitializePurchasing()
    {
        if (IsInitialized())
            return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(googlePlayPremium, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null && extensionProvider != null;
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
        Debug.Log(product);
        PurchasePickPack();

        premiumButton.SetActive(false);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product " + product.definition.id + " failed due to " + reason);
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        extensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", i.definition.storeSpecificId, p));
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (string.Equals(args.purchasedProduct.definition.id, googlePlayPremium, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            PurchasePickPack();
        }
        return PurchaseProcessingResult.Complete;
    }
}
