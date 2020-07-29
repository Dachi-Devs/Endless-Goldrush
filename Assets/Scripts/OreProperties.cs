using UnityEngine;

public class OreProperties : MonoBehaviour, IMinableObject
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

    public void OnMine()
    {
        GameManager.instance.AddToScore((int)ore.value);
        Destroy(gameObject);
    }
}
