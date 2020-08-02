using UnityEngine;
using UnityEngine.UI;

public class PickFrame : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO pickaxeSelection;

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

    public void OnClick() => FindObjectOfType<PickaxeSelection>().SetSelection(pickaxeSelection);
}
