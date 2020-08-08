using UnityEngine;
using UnityEngine.UI;

public class PickFrame : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO pickaxeSelection;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private int cost;

    [SerializeField]
    private GameObject lockImage;

    // Start is called before the first frame update
    void Start()
    {
        Image childImage = GetComponentsInChildren<Image>()[1];
        if (pickaxeSelection != null)
            childImage.sprite = pickaxeSelection.sprite;
        else
        {
            childImage.sprite = null;
            childImage.color = Color.clear;
        }
    }

    public void UnlockPick()
    {
        isLocked = false;
        lockImage.SetActive(false);
        FindObjectOfType<PickaxeSelection>().SetSelection(pickaxeSelection);
        FindObjectOfType<ShopManager>().SetShopSelection(null);
    }

    public void OnClick()
    {
        if (pickaxeSelection == null)
        {
            return;
        }
        FindObjectOfType<ShopDescription>().SetDescKeys(pickaxeSelection.pickNameKey, pickaxeSelection.pickDescKey);
        if (!isLocked)
        {
            FindObjectOfType<PickaxeSelection>().SetSelection(pickaxeSelection);
            FindObjectOfType<ShopManager>().SetShopSelection(null);
        }
        else
        {
            FindObjectOfType<ShopManager>().SetShopSelection(this);
        }
    }

    public int GetCost() => cost;

    public bool GetIsLocked() => isLocked;

    public string GetName() => pickaxeSelection.name;
}
