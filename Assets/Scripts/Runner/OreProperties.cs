using UnityEngine;

public class OreProperties : MonoBehaviour, IMinableObject
{
    private OreSO ore;

    [SerializeField]
    private SpriteRenderer oreVeinSprite;

    [SerializeField]
    private GameObject smashParticles;


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
        GameObject particles = Instantiate(smashParticles, transform.position, Quaternion.Euler(new Vector3(0f, 90f, 0f)));
        Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration + 0.3f);
        gameObject.SetActive(false);
    }
}
