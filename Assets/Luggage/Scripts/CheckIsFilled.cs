using UnityEngine;

public class CheckIsFilled : MonoBehaviour
{
    [SerializeField] private LuggageScript luggageScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject parentObject;
    private int width, length;

    private void Awake()
    {
        parentObject = transform.parent.gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        luggageScript = parentObject.GetComponent<LuggageScript>();
    }

    private void Update()
    {
        CheckColumn();
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
                parentObject.transform.position = luggageScript.ObjectDefaultPosition;
            }
        }
    }

    private void ResetColumn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.IsOnObject[width, length] = false;
        }
    }
}