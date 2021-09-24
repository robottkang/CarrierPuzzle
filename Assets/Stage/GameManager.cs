using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject HighlightTile;
    [SerializeField] private StageData carrierSize;
    [SerializeField] private int numberOfWidthColumn;
    public int NumberOfWidthColumn
    {
        get => numberOfWidthColumn;
        set => numberOfWidthColumn = value;
    }
    [SerializeField] private int numberOfLengthColumn;
    public int NumberOfLengthColumn
    {
        get => numberOfLengthColumn;
        set => numberOfLengthColumn = value;
    }
    [SerializeField] private float highlightTileMoveDistance;
    private bool[,] isOnObject;
    public bool[,] IsOnObject
    {
        get => isOnObject;
        set => isOnObject = value;
    }
private GameObject luggage;
    private int luggageNumber;

    private void Start()
    {
        isOnObject = new bool[numberOfWidthColumn, numberOfLengthColumn];
        for (int i = 0; i < numberOfWidthColumn; i++)
        {
            for (int j = 0; j < numberOfLengthColumn; j++)
            {
                isOnObject[i,j] = false;
            }
        }
    }
    private void Update()
    {
        HighlightTileMoving();
        HighlightTileActive();
    }

    private void HighlightTileActive()
    {
        if ((mainCamera.ScreenToWorldPoint(Input.mousePosition).x < carrierSize.LimitMax.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > carrierSize.LimitMin.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y < carrierSize.LimitMax.y) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y > carrierSize.LimitMin.y) &&
             Input.GetMouseButton(0) == true) HighlightTile.SetActive(true);
        else
        {
            HighlightTile.SetActive(false);
            HighlightTile.transform.position = new Vector3(-0.5f, 0.5f, 0f);
        }
    }

    private void HighlightTileMoving()
    {
        if (Input.GetMouseButton(0) == true)
        {
            Vector3 mouseWorldPosition = new Vector3(
            (float)(int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x * highlightTileMoveDistance + 0.5f,
            (float)(int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y * highlightTileMoveDistance + 0.5f, 0f);
            HighlightTile.transform.position = mouseWorldPosition;
        }
    }

    private void CallObject()
    {
        luggage = Resources.Load("Luggage" + luggageNumber) as GameObject;
    }
}