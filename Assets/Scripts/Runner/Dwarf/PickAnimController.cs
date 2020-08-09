using System;
using UnityEngine;

public class PickAnimController : MonoBehaviour
{
    public Animator anim;

    public event EventHandler OnSwingEnd;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartSwing()
    {
        anim.SetTrigger("Mine");
    }

    public void SwingHit()
    {
        OnSwingEnd?.Invoke(this, EventArgs.Empty);
    }

    public void EndSwing()
    {
        anim.SetBool("Mine", false);
    }

    public void StartIdle()
    {
        anim.SetBool("Mine", false);
    }

    public bool MineBool() => anim.GetBool("Mine");
}
