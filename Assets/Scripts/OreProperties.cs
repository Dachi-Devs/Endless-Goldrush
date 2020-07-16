using UnityEngine;

public class OreProperties : MonoBehaviour
{
    private OreSO ore;

    [SerializeField]
    private SpriteRenderer oreVeinSprite;
    // Start is called before the first frame update


    private void Setup()
    {
        oreVeinSprite.sprite = ore.sprite;
    }

    public void SetOre(OreSO oreToSet)
    {
        ore = oreToSet;
        Setup();
    }

    public float GetOreValue() => ore.value;
}
