using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlatform : MonoBehaviour
{
    [Tooltip("Introduce un la plataforma Teleport 2 como destino")]
    public Transform destination;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.transform.position = destination.position;
        }

    }
}
