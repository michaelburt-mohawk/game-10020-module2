using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour, IHittable
{
    public Sprite toggleOn;
    public Sprite toggleOff;
    public bool toggleState { get; private set; } = false;


    SpriteRenderer spriteRenderer;
    Animator animator;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void UpdateState()
    {
        spriteRenderer.sprite = toggleState ? toggleOn : toggleOff;
        animator.SetTrigger("StartHit");
    }

    public void Hit(GameObject gameObject)
    {
        toggleState = !toggleState;
        UpdateState();
    }
}
