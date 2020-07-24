using UnityEngine;
using UnityEngine.PlayerLoop;

public class PickaxeProperties : MonoBehaviour
{
    [SerializeField]
    private PickaxeSO pickaxe;

    void Start()
    {
        UpdatePick();
    }

    public void SetPick(PickaxeSO pickToSet)
    {
        pickaxe = pickToSet;
        UpdatePick();
    }

    private void UpdatePick()
    {
        GetComponent<SpriteRenderer>().sprite = pickaxe.sprite;
    }
}
