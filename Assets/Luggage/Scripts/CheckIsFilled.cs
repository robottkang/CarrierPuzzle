using UnityEngine;

public class CheckIsFilled : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] LuggageScript luggageScript;
    [SerializeField] StageData carrierSize;
    [SerializeField] GameObject parentObject;
    private int width, length;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ResetColumn();
    }

    private void LateUpdate()
    {
        CheckColumn();
    }

    private void CheckColumn()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            if (transform.position.x > carrierSize.LimitMin.x &&
                transform.position.x < carrierSize.LimitMax.x &&
                transform.position.y > carrierSize.LimitMin.y &&
                transform.position.y < carrierSize.LimitMax.y)
            {
                width = (int)(transform.position.x - carrierSize.LimitMin.x);
                length = (int)(transform.position.y - carrierSize.LimitMin.y);
                if (gameManager.IsOnObject[width, length] == true)
                {
                    luggageScript.IsWrong = true;
                    parentObject.transform.position = luggageScript.ObjectDefaultPosition;
                }
                else
                {
                    gameManager.IsOnObject[width, length] = true;
                }
            }
            else parentObject.transform.position = luggageScript.ObjectDefaultPosition;
        }
    }

    private void ResetColumn()
    {
        if (luggageScript.IsWrong == true || Input.GetMouseButtonDown(0) == true)
        {
            gameManager.IsOnObject[width, length] = false;
            luggageScript.IsWrong = false;
        }
    }
}