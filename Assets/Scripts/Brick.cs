using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anim = GetComponent<Animator>();
        Invoke(nameof(Fall), 2);
    }
    private void Fall()
    {
        anim.SetTrigger("StartFall");
        rb.gravityScale = 1;
        transform.parent.DetachChildren();
    }

}
