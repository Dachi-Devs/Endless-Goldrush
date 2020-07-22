using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Pickaxe", menuName = "Pickaxes/New Pickaxe")]
public class PickaxeSO : ScriptableObject
{
    public Sprite sprite;
    public string pickNameKey;
    public string pickDescKey;
}
