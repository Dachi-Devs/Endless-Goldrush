using System;
using UnityEngine;

public class RunForward : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed;

    private bool run = true;

    [SerializeField]
    private bool godMode = false;

    public event EventHandler OnDeath;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void FixedUpdate()
    {
        if (run)
            rb2d.velocity = new Vector2(1f * moveSpeed, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (!godMode)
            {
                run = false;
                OnDeath?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            FindObjectOfType<LevelSpawner>().SpawnChunk();
        }
    }
}
