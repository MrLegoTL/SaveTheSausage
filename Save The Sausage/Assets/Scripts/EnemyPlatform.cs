using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatform : MonoBehaviour
{
    public float speedPlatform = 2f;
    public float verticalRange = 4f;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        //Calcula es desplazamiento vertical
        float moveVertical = Mathf.PingPong(Time.time * speedPlatform, verticalRange);

        //Calcula la nueva posicion de la plataforma
        Vector3 newPosition = initialPosition + Vector3.up * moveVertical;

        //Aplica la nueva posicion a la plataforma
        transform.position = newPosition;

    }
}
