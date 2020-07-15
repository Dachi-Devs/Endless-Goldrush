using UnityEngine;

public class OreProperties : MonoBehaviour
{
    [SerializeField]
    private OreSO ore;

    [SerializeField]
    private SpriteRenderer oreVeinSprite;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        oreVeinSprite.sprite = ore.sprite;
    }

    public float GetOreValue() => ore.value;
}
