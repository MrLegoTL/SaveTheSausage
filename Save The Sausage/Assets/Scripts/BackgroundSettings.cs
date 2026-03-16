using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr=GetComponent<SpriteRenderer>();
        if (sr == null) return;

        //Obtenemos limites de la camara
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect;

        // Obtenemos el tamaño del sprite
        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

       // Calculamos las escalas necesarias
        float scaleX = width / spriteWidth;
        float scaleY = height / spriteHeight;


        // Usamos la escala MAYOR para asegurar que cubra todo
        float scale = Mathf.Max(scaleX, scaleY);

        // Aplicamos la escala
        transform.localScale = new Vector3(scale, scale, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
