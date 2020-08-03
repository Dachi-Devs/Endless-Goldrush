using UnityEngine;
using UnityEngine.UI;

public class PickFrame : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO pickaxeSelection;

    [SerializeField]
    private bool isLocked;

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
    }

    public void OnClick()
    {
        if (!isLocked)
        {
            FindObjectOfType<ShopManager>().SetShopSelection(null);
            FindObjectOfType<PickaxeSelection>().SetSelection(pickaxeSelection);
        }
        else
        {
            //Display Buy Button
        }
    }
}
