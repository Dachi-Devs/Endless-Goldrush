using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PickFrame : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO pickaxeSelection;

    [SerializeField]
    protected bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocked)
        {
            GetComponentsInChildren<Image>()[2].gameObject.SetActive(true);
        }
        else
        {
            GetComponentsInChildren<Image>()[2].gameObject.SetActive(false);
        }

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
        GetComponentsInChildren<Image>()[2].gameObject.SetActive(false);
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
}
