using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Drag drag;
    public Camera mainCamera;
    private Vector3 childObjectPosition;
    [HideInInspector] public bool isDownMouseLeftButton;

    private void Awake()
    {
        drag = transform.gameObject.GetComponent<Drag>();
        isDownMouseLeftButton = false;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        DetectLeftClick();
    }

    private void DetectLeftClick()
    {
        if (drag.IsInMouse && Input.GetMouseButtonDown(1))
        {
            transform.RotateAround(transform.position, Vector3.forward, 90);
        }
    }
}