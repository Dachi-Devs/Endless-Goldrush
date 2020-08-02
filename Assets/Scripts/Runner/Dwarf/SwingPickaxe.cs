﻿using System;
using UnityEngine;

public class SwingPickaxe : MonoBehaviour
{
    [SerializeField]
    private LayerMask floorLayer;
    [SerializeField]
    private LayerMask obstacleLayer;

    private bool dead;

    [SerializeField]
    private GameObject pickaxe;
    


    void Awake()
    {
        FindObjectOfType<PickAnimController>().OnSwingEnd += AnimController_OnSwingEnd;
        GetComponent<RunForward>().OnDeath += RunForward_OnDeath;
    }

    void Update()
    {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
            {
                PickAnimController pick = GetComponentInChildren<PickAnimController>();
                if (!pick.GetAnimState())
                    pick.StartSwing();
            }
        }

    }
    private void RunForward_OnDeath(object sender, EventArgs e)
    {
        dead = true;
    }

    private void AnimController_OnSwingEnd(object sender, System.EventArgs e)
    {
        if (IsMining(out GameObject ore))
        {
            Mine(ore);
        }
        else if (IsGrounded())
        {
            GetComponent<Jump>().DoJump();
        }
    }

    private void Mine(GameObject objectMined)
    {
        IMinableObject objectHit = objectMined.GetComponent<IMinableObject>();
        objectHit.OnMine();
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