using System;
using UnityEngine;

public class PickAnimController : MonoBehaviour
{
    protected Animator anim;

    public event EventHandler OnSwingEnd;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartSwing()
    {
        anim.SetBool("isMining", true);
    }

    public void SwingHit()
    {
        OnSwingEnd?.Invoke(this, EventArgs.Empty);
    }

    public void EndSwing()
    {
        anim.SetBool("isMining", false);
    }

    public bool GetAnimState() => anim.GetBool("isMining");
}
