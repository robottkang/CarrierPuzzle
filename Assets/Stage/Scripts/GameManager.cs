using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject HighlightTile;
    [SerializeField] private List<GameObject> carriers = new List<GameObject>();
    private Camera mainCamera;
    private StageMenuManager stageMenuManager;
    private GameObject carrierData;
    public GameObject CarrierData => carrierData;
    private int stageNumber = 0;
    private int numberOfWidthColumn;
    private int numberOfLengthColumn;
    private bool[,] isOnObject;
    public int StageNumber { get => stageNumber; set => stageNumber = value; }
    public int NumberOfWidthColumn => numberOfWidthColumn;
    public int NumberOfLengthColumn => numberOfLengthColumn;
    public bool[,] IsOnObject { get => isOnObject; set => isOnObject = value; }

    private void Awake()
    {
        carrierData = carriers[stageNumber];
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        numberOfWidthColumn = (int)carriers[stageNumber].transform.lossyScale.x;
        numberOfLengthColumn = (int)carriers[stageNumber].transform.lossyScale.y;
        isOnObject = new bool[numberOfWidthColumn, numberOfLengthColumn];
        Instantiate(carriers[stageNumber], new Vector3(5, 6, 2), Quaternion.identity);
        for (int i = 0; i < numberOfWidthColumn; i++)
        {
            for (int j = 0; j < numberOfLengthColumn; j++)
            {
                isOnObject[i, j] = false;
            }
        }
    }

    private void Start()
    {
        if (GameObject.Find("StageMenuManager") != null)
        {
            stageMenuManager = GameObject.Find("StageMenuManager").GetComponent<StageMenuManager>();
            stageNumber = stageMenuManager.EnteredStageNumber;
        }
    }

    private void Update()
    {
        Debug.Log(stageNumber);
        HighlightTileMoving();
        HighlightTileActive();
    }

    private void HighlightTileActive()
    {
        if ((mainCamera.ScreenToWorldPoint(Input.mousePosition).x < carriers[stageNumber].transform.position.x + (carriers[stageNumber].transform.lossyScale.x / 2)) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > carriers[stageNumber].transform.position.x - (carriers[stageNumber].transform.lossyScale.x / 2)) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y < carriers[stageNumber].transform.position.y + (carriers[stageNumber].transform.lossyScale.y / 2)) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y > carriers[stageNumber].transform.position.y - (carriers[stageNumber].transform.lossyScale.y / 2)) &&
             Input.GetMouseButton(0) == true)
        {
            HighlightTile.SetActive(true);
            Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
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
            (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x + 0.5f,
            (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y + 0.5f, 0f);
            HighlightTile.transform.position = mouseWorldPosition;
        }
    }

    public void DestroyUsedStageMenuManager()
    {
        Destroy(GameObject.Find("StageMenuManager"));
    }
}