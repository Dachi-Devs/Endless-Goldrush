﻿using UnityEngine;

public class RunForward : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed;

    private bool run = true;


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
            run = false;
            Destroy(GetComponent<SwingPickaxe>());
            GetComponentInChildren<DwarfAnimController>().Death();
            FindObjectOfType<GameManager>().OnDeath();
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