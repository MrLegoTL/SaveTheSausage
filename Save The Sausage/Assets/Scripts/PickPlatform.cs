using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPlatform : MonoBehaviour
{
    public float force = 500f;
    Rigidbody2D selectedRigidbody;

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
            if(selectedRigidbody != null)
            {
                selectedRigidbody.velocity = Vector2.zero;
            }
            
            selectedRigidbody = null;
        }
    }

    Rigidbody2D GetRigidBodyFromMouseClick()
    {
         Vector2  clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit =Physics2D.Raycast(clickPoint, Vector2.zero);

        if (hit)
        {
            Rigidbody2D hitRigidbody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            if (hitRigidbody !=null)
            {
                return hitRigidbody;
            }
        }
        return null;
    }
}
