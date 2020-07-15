using System;
using UnityEngine;

public class DwarfAnimController : MonoBehaviour
{
    protected Animator anim;

    public event EventHandler OnSwingEnd;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger("Dead");
    }
}
