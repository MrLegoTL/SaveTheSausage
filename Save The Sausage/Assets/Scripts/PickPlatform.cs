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
            Vector3 dir = Camera.main.ScreenToWorldPoint(GetInputPosition()) - selectedRigidbody.transform.position;
            selectedRigidbody.velocity = dir * force * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        //Detecta el inicio del toque/clic
        if (GetInputDown())
        {
            selectedRigidbody = GetRigidBodyFromMouseClick();
        }

        //Detecta cuando se suelta el toque/clic
        if(GetInputUp())
        {
            if(selectedRigidbody != null)
            {
                selectedRigidbody.velocity = Vector2.zero;
            }
            
            selectedRigidbody = null;
        }

        if (!PickableObjects.instance.canMove && inZone)
        {
            Destroy(gameObject);
        }
    }


   //Detecta si se presiono con raton o tactil
    private bool GetInputDown()
    {
        return Input.GetMouseButtonDown(0) || (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    //Detecta si se dejo de presiona con raton o tactil.
    private bool GetInputUp()
    {
        return Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
    }

    //Obtiene la posicion del Input tanto para raton como tactil
    private Vector3 GetInputPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;

        }
        return Input.mousePosition;
    }

    Rigidbody2D GetRigidBodyFromMouseClick()
    {
         Vector2  clickPoint = Camera.main.ScreenToWorldPoint(GetInputPosition());
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
