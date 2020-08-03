using UnityEngine;
using UnityEngine.Rendering;

public class Barrel : MonoBehaviour, IMinableObject
{
    [SerializeField]
    private GameObject smokeParticles;

    public void OnMine()
    {
        Destroy(GetComponent<BoxCollider2D>());

        int effect = Random.Range(0, 100);

        if (effect < 5)
        {
            //EXPLODE SOUND
            GameObject particles = Instantiate(smokeParticles, transform.position, Quaternion.identity);
            FindObjectOfType<RunForward>().KillPlayer();
            Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration + 0.3f);
        }

        else if (effect < 25)
        {
            GameManager.instance.AddToScore(100);
        }

        else if (effect < 50)
        {
            GameManager.instance.AddToScore(1);
        }

        else if (effect < 51)
        {
            GameManager.instance.AddToScore(10000);
        }

        GetComponent<Animator>().SetBool("IsBroken", true);
    }

    private void AnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
