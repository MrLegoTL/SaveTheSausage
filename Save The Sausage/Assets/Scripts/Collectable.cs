using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public Collider2D collider;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        collider=GetComponent<Collider2D>();
        spriteRenderer=GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collider.enabled = false;
            spriteRenderer.enabled = false;
            particles.Play();
            Destroy(gameObject, 0.6f);
        }
    }
}
