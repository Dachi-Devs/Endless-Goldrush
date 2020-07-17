using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDwarf : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 25)
        {
            transform.position = new Vector2(-20f, transform.position.y);
        }

        float doJump = Random.Range(0, 1000);
        if (doJump < 1)
        {
            GetComponent<Jump>().DoJump();
        }
    }
}
