using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private StageData carrierSize;
    private Vector3 minVector;
    private Vector3 maxVector;
    private Vector3 mouseDefaultPosition;
    private Vector3 parentObjectDefaultPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 offset;
    int width, length;
    bool isInMouse;

    private void Start()
    {
        minVector = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0f);
        maxVector = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0f);
    }

    private void Update()
    {
        MoveObject();
        CheckWhereBlockIs();
    }

    private void MoveObject()
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
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

    private void CheckWhereBlockIs()// 미완 : 오른쪽으로 오브젝트가 나가도 기존 위치로 돌아가지 않음
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            width = (int)transform.position.x - (int)carrierSize.LimitMin.x;
            length = (int)transform.position.y - (int)carrierSize.LimitMin.y;
            if (width >= 0 && width <= gameManager.NumberOfWidthColumn && length >= 0 && length <= gameManager.NumberOfLengthColumn)
            {
                gameManager.IsOnObject[width, length] = false;
            }
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
            if (width >= 0 && width <= gameManager.NumberOfWidthColumn && length >= 0 && length <= gameManager.NumberOfLengthColumn)
                gameManager.IsOnObject[width, length] = true;
            else parentObject.transform.position = parentObjectDefaultPosition;
        }
    }
}