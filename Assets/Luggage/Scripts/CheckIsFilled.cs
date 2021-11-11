using UnityEngine;

public class CheckIsFilled : MonoBehaviour
{
    [SerializeField] private Drag drag;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject parentObject;
    private Camera mainCamera;
    private int width, length;

    private void Awake()
    {
        parentObject = transform.parent.gameObject;
        //mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        drag = parentObject.GetComponent<Drag>();
    }

    private void Update()
    {
        CheckColumn();
        //DetectMouse();
    }

    private void LateUpdate()
    {
        ResetColumn();
    }

    private void CheckColumn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (transform.position.x < gameManager.Carriers[gameManager.stageNumber].transform.position.x + (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.x / 2) &&
                transform.position.x > gameManager.Carriers[gameManager.stageNumber].transform.position.x - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.x / 2) &&
                transform.position.y < gameManager.Carriers[gameManager.stageNumber].transform.position.y + (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.y / 2) &&
                transform.position.y > gameManager.Carriers[gameManager.stageNumber].transform.position.y - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.y / 2))
            // 캐리어 안에 위치해 있으면
            {
                width = (int)(transform.position.x - (gameManager.Carriers[gameManager.stageNumber].transform.position.x - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.x / 2)));
                length = (int)(transform.position.y - (gameManager.Carriers[gameManager.stageNumber].transform.position.y - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.y / 2)));
                gameManager.IsOnObject[width, length] = true;
            }
            if (transform.position.x > gameManager.stageData.LimitMax.x ||
                transform.position.x < gameManager.stageData.LimitMin.x ||
                transform.position.y > gameManager.stageData.LimitMax.y ||
                transform.position.y < gameManager.stageData.LimitMin.y)
            {
                parentObject.transform.position = drag.ObjectDefaultPosition;
            }
        }
    }
    /*
    private void DetectMouse()
    {
        if (mainCamera.ScreenToWorldPoint(Input.mousePosition).x < (transform.position.x + 0.5f) &&
           mainCamera.ScreenToWorldPoint(Input.mousePosition).x > (transform.position.x - 0.5f) &&
           mainCamera.ScreenToWorldPoint(Input.mousePosition).y < (transform.position.y + 0.5f) &&
           mainCamera.ScreenToWorldPoint(Input.mousePosition).y > (transform.position.y - 0.5f))
        {
                
        }
    }*/

    private void ResetColumn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.IsOnObject[width, length] = false;
        }
    }
}