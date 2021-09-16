using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject parentObject;
    private Vector3 minVector;
    private Vector3 maxVector;
    private Vector3 mouseDefaultPosition;
    private Vector3 parentObjectDefaultPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 offset;
    bool isInMouse;

    private void Start()
    {
        minVector = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0f);
        maxVector = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0f);
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        Debug.Log(mouseWorldPosition);
        if ((mainCamera.ScreenToWorldPoint(Input.mousePosition).x < maxVector.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > minVector.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y < maxVector.y) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y > minVector.y) &&
            Input.GetMouseButtonDown(0) == true)
        {
            mouseDefaultPosition = mouseWorldPosition;
            parentObjectDefaultPosition = parentObject.transform.position;
            isInMouse = true;
        }

        if (isInMouse && Input.GetMouseButton(0) == true)
        {
            offset = mouseDefaultPosition - mouseWorldPosition;
            parentObject.transform.position = new Vector3(parentObjectDefaultPosition.x - offset.x, parentObjectDefaultPosition.y - offset.y, 0f);
        }
        else
        {
            minVector = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0f);
            maxVector = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0f);
        }

        if (isInMouse && Input.GetMouseButtonUp(0) == true)
        {
            parentObject.transform.position = new Vector3((int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x + (int)(parentObject.transform.position.x - transform.position.x), (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y + (int)(parentObject.transform.position.y - transform.position.y), 0f);
            isInMouse = false;
        }
    }
}