using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnim : MonoBehaviour
{
    public int ClipCount;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void NextAction()
    {
        animator.SetInteger("Act", Random.Range(0, ClipCount));
    }
}

