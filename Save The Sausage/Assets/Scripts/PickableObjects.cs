using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjects : MonoBehaviour
{

    // Variables para el objeto que genera el raycast
    public Camera cam;
    public Transform positionPick;
    public Transform objectPosition;

    // Variables para el raycast
    public float distance;
    public RaycastHit2D hit;
    public LayerMask mask;

    // Variables para los objetos
    public bool pickedObject;

    public static PickableObjects instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastObject();
    }

    public void RaycastObject()
    {
        positionPick.position = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics2D.Raycast(transform.position, transform.forward, distance, mask))
            {

            }
        }

    }




}
