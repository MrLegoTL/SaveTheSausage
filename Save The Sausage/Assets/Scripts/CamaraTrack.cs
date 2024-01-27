using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTrack : MonoBehaviour
{
    //transform del objetivo a seguir. Es un valor por referencia, por lo que siempre dispondremos del valor actualizado
    public Transform target;

    //para indicar si la camara seguira al objetivo horizontalmente
    public bool followX = true;
    //desviación de la posicion en el eje X, para dar margen de vision
    [Range(-20, 20)]
    public float offsetX = 1;

    //para indicar si la camara seguira al objetivo verticalmente
    public bool followY = false;
    //desviacion de la posicion en Y para dar margen de vision
    [Range(-2, 2)]
    public float offsetY = 0;



    public void CameraMove()
    {
        //creo un vector de posicion temporal
        Vector3 newPos = transform.position;

        // en caso de estra activo el seguimiento, actualizo con la posicion del objetivo + el offset especificado
        if (followX) newPos.x = target.position.x + offsetX;
        if (followY) newPos.y = target.position.y + offsetY;

        //finalmentee actualizamos la posicion de la camara
        transform.position = newPos;
    }
}
