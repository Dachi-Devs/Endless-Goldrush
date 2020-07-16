﻿using UnityEngine;

public class SwingPickaxe : MonoBehaviour
{
    [SerializeField]
    private LayerMask floorLayer;
    [SerializeField]
    private LayerMask obstacleLayer;

    private Rigidbody2D rb2d;

    [SerializeField]
    private GameObject pickaxe;
    
    [SerializeField]
    private float jumpForce;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        FindObjectOfType<PickAnimController>().OnSwingEnd += AnimController_OnSwingEnd;
        if (rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            PickAnimController pick = GetComponentInChildren<PickAnimController>();
            if (!pick.GetAnimState())
                pick.StartSwing();
        }
    }

    private void AnimController_OnSwingEnd(object sender, System.EventArgs e)
    {
        if (IsMining(out GameObject ore))
        {
            Mine(ore);
        }
        else if (IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb2d.velocity = Vector3.up * jumpForce;
    }

    private void Mine(GameObject oreToMine)
    {
        OreProperties ore = oreToMine.GetComponent<OreProperties>();
        GameManager.instance.AddToScore(ore.GetOreValue());

        Destroy(ore.gameObject);
    }

    private bool IsGrounded()
    {
        CircleCollider2D box = GetComponent<CircleCollider2D>();
        RaycastHit2D ray = Physics2D.Raycast(box.bounds.center, Vector2.down, 1.2f, floorLayer);
        return ray.collider != null;
    }

    private bool IsMining(out GameObject ore)
    {
        CircleCollider2D box = GetComponent<CircleCollider2D>();
        RaycastHit2D ray = Physics2D.Raycast(box.bounds.center, Vector2.right, 5f, obstacleLayer);
        if (ray)
            ore = ray.transform.gameObject;
        else
            ore = null;
        return ray.collider != null;
    }
}