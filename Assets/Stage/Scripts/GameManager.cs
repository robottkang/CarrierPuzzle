using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool testMode;
    [SerializeField] private int customStageNumber;
    [SerializeField] private GameObject backColor;
    [SerializeField] private GameObject clearMenu;
    [SerializeField] private GameObject HighlightTile;
    [SerializeField] private List<GameObject> carriers = new List<GameObject>();
    [SerializeField] private List<GameObject> luggageSet = new List<GameObject>();
    public StageData stageData;
    public List<GameObject> Carriers => carriers;
    public List<GameObject> LuggageSet => luggageSet;
    private Camera mainCamera;
    [HideInInspector] public int stageNumber = 0;
    private int numberOfWidthColumn;
    private int numberOfLengthColumn;
    private bool[,] isOnObject;
    private bool checkField;
    private bool isClear;
    public bool IsClear => isClear;
    public int NumberOfWidthColumn => numberOfWidthColumn;
    public int NumberOfLengthColumn => numberOfLengthColumn;
    public bool[,] IsOnObject { get => isOnObject; set => isOnObject = value; }

    private void Awake()
    {
        if (!testMode) stageNumber = PlayerPrefs.GetInt("StageNumber");
        else stageNumber = customStageNumber;
        backColor.SetActive(false);
        clearMenu.SetActive(false);
        checkField = false;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        numberOfWidthColumn = (int)carriers[stageNumber].transform.lossyScale.x;
        numberOfLengthColumn = (int)carriers[stageNumber].transform.lossyScale.y;
        isOnObject = new bool[numberOfWidthColumn, numberOfLengthColumn];
        for (int i = 0; i < numberOfWidthColumn; i++)
        {
            for (int j = 0; j < numberOfLengthColumn; j++)
            {
                isOnObject[i, j] = false;
            }
        }
        Instantiate(carriers[stageNumber], new Vector3(5, 6, 2), Quaternion.identity);
        Instantiate(luggageSet[stageNumber], new Vector3(12, 1, 0), Quaternion.identity);
    }

    private void Update()
    {
        CheckIsClearStage();
        ClearEvent();
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
            HighlightTileMoving();
        }
        else
        {
            HighlightTile.transform.position = new Vector3(-0.5f, 0.5f, 1.5f);
        }
    }

    private void HighlightTileMoving()
    {
        Vector3 mouseWorldPosition = new Vector3(
        (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x + 0.5f,
        (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y + 0.5f, 1.5f);
        HighlightTile.transform.position = mouseWorldPosition;
    }

    private void CheckIsClearStage()
    {
        checkField = true;
        for (int i = 0; i < numberOfWidthColumn && checkField; i++)
        {
            for (int j = 0; j < numberOfLengthColumn; j++)
            {
                if (isOnObject[i, j] == false)
                {
                    checkField = false;
                    break;
                }
            }
        }
        if (checkField == true) isClear = true;
    }

    private void ClearEvent()
    {
        if (isClear == true)
        {
            backColor.SetActive(true);
            clearMenu.SetActive(true);
            if(!testMode)
                if (PlayerPrefs.GetInt("ClearData") < stageNumber)
                {
                    PlayerPrefs.SetInt("ClearData", stageNumber);
                    Debug.Log(PlayerPrefs.GetInt("ClearData"));
                }
        }
    }
}