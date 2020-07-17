using UnityEngine;

public class PickaxeProperties : MonoBehaviour
{
    [SerializeField]
    private Sprite pickSprite;

    void Start()
    {
        SetPickSprite();
    }

    private void SetPickSprite()
    {
        GetComponent<SpriteRenderer>().sprite = pickSprite;
    }
}
