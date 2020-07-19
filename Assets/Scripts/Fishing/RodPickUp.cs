using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodPickUp : MonoBehaviour
{
    public float startForceUp = 6f;
    public float startForceLeft = 2f;
    
    public RuntimeAnimatorController playerwithrod;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForceUp, ForceMode2D.Impulse);
        rb.AddForce(-transform.right * startForceLeft, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Animator animator = col.gameObject.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = playerwithrod;
            col.gameObject.GetComponent<PlayerMovement>().playerrod = true;
            Destroy(gameObject);
        }
    }
}
