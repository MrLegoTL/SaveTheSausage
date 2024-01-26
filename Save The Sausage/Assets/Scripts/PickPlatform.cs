using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPlatform : MonoBehaviour
{
    public float force = 500f;
    Rigidbody2D selectedRigidbody;
    public bool inZone;

    private void FixedUpdate()
    {
        if (selectedRigidbody)
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - selectedRigidbody.transform.position;
            selectedRigidbody.velocity = dir * force * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedRigidbody = GetRigidBodyFromMouseClick();
        }

        if(Input.GetMouseButtonUp(0))
        {
            selectedRigidbody.velocity = Vector2.zero;
            selectedRigidbody = null;
        }

        if (!PickableObjects.instance.canMove && inZone)
        {
            Destroy(gameObject);
        }
    }

    Rigidbody2D GetRigidBodyFromMouseClick()
    {
         Vector2  clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit =Physics2D.Raycast(clickPoint, Vector2.zero);

        if (hit)
        {
            if(hit.collider.gameObject.GetComponent<Rigidbody2D>()) 
            { 
                return hit.collider.gameObject.GetComponent<Rigidbody2D>();
            }
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platformzone"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platformzone"))
        {
            inZone = false;
        }
    }
}
