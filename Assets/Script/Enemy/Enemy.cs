using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    //Attributes
    public Rigidbody2D rb;

    //Method
    public abstract void Behavior();

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (player.GetComponent<Rigidbody2D>().velocity.y >= -5)
                {
                    player.TakeDamage();
                }
                else
                {
                    TakeDamage();
                }
            }
        }
    }
}
