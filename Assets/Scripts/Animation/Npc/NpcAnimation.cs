using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimation : MonoBehaviour
{
    public Animator anim;

    private Throwables thr;

    void Start()
    {
        thr = gameObject.GetComponent<Throwables>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", thr.Speed);
        anim.SetBool("Flying", thr.Flying);
        anim.SetBool("Held", thr.Held);
        anim.SetBool("Landed", thr.Landed);
    }
}
