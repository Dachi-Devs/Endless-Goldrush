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
        FindObjectOfType<RunForward>().OnDeath += RunForward_OnDeath;
    }

    private void RunForward_OnDeath(object sender, EventArgs e)
    {
        anim.SetTrigger("Dead");
    }
}
