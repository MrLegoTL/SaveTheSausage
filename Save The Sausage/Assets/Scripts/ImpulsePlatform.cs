using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsePlatform : MonoBehaviour
{
    public float impulse = 10f;
    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.AddImpulse(impulse);
            ani.SetBool("impulse", true);
        }
    }
}
