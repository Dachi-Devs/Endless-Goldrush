using UnityEngine;

public class Barrel : MonoBehaviour, IMinableObject
{
    public void OnMine()
    {
        Destroy(GetComponent<BoxCollider2D>());
        GetComponent<Animator>().SetBool("IsBroken", true);
    }

    private void AnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
