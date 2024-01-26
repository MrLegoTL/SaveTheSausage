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
    public ParticleSystem particlePrefabs;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //particlePrefabs.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ImpulseDuration();
        RotatePlayer();
        if (grounded && (Mathf.Abs(rb.velocity.y) < 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f))
        {
            ActiveParticles(true);
            var mainModule = particlePrefabs.main;
            mainModule.simulationSpeed = Mathf.Abs(rb.velocity.x) * 0.5f;
        }
        else
        {
            ActiveParticles(false);
        }
    }

    public void Move()
    {

        if (grounded)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
    }

    void RotatePlayer()
    {
        if (grounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Platform"));
            if(hit.collider != null)
            {
                float inclination = Vector2.Angle(hit.normal, Vector2.up);
                transform.rotation = Quaternion.FromToRotation(Vector2.up, hit.normal);
            }
            else
            {
                // Si no está en el suelo, deja de rotar
                transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            // Si no está en el suelo, deja de rotar
            transform.rotation = Quaternion.identity;
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            grounded = true;
            
        }
     

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "WinPlatform")
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
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

    void ActiveParticles(bool active)
    {


        if (particlePrefabs != null)
        {
            if (active && !particlePrefabs.isPlaying )
            {
                particlePrefabs.Play();
            }
            else if (!active && particlePrefabs.isPlaying )
            {
                particlePrefabs.Stop();
            }
        }
    }
    
    
}
