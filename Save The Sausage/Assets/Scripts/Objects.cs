using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CanMove();
    }

    public void CanMove()
    {
        if (PickableObjects.instance.pickedObject)
        {
            this.transform.position = PickableObjects.instance.positionPick.position;
        }
        else return;
    }

}
