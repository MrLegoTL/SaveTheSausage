using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableObjects : MonoBehaviour
{

    [Header("Variables para el modo construcción")]
    public bool canMove = true;
    public GameObject playButton;
    public GameObject panelPlatformZone;
    public Rigidbody2D playerRB;

    [Header("Variables para el modo play")]
    public float initialZoom;
    public float finalZoom;
    public float retard;
    public Transform playerPos;

    Camera cam;
    [Header("Variables de la cámara")]
    public float minPos; 
    public float maxPos;

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
        cam.orthographicSize = initialZoom;

        if (canMove) return;

        else
        {
            CamaraTrack cam = FindObjectOfType<CamaraTrack>();

            float playerPosX = playerPos.position.x;
            initialZoom = Mathf.Lerp(initialZoom, finalZoom, retard);
            Invoke("CanMovePlayer", 0.6f);

            if (playerPosX > minPos && playerPosX < maxPos)
            {
                cam.CameraMove();
                //cam.transform.position = playerPos.position;
            }
        }
    }

    public void ActivatePlay()
    {
        canMove = false;
        playButton.SetActive(false);
        panelPlatformZone.SetActive(false);

        HandsController.instance.handsAnimator.SetBool("drop", true);
    }

    public void CanMovePlayer()
    {
        playerRB.isKinematic = false;
    }




}
