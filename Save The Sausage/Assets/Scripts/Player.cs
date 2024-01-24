using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 5f;
    public bool grounded = false;
    [SerializeField]
    private float timeImpulse = 0f;
    [SerializeField]
    private float currentImpulse;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ImpulseDuration();
    }

    public void Move()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            grounded = true;
            
        }
        else
        {
            grounded = false;
            
        }
    }

    public void AddImpulse(float impulse)
    {
        currentImpulse = impulse;
        timeImpulse = 1f;
    }
    void ImpulseDuration()
    {
        if (timeImpulse > 0)
        {
            rb.velocity = new Vector2(currentImpulse, rb.velocity.y);
            timeImpulse -= Time.deltaTime;
            Debug.Log("Impuso cogido");
        }
        else if (timeImpulse <= 0)
        {
            currentImpulse = 0f;
            Debug.Log("No hay impulso");
        }
    }

    
}
