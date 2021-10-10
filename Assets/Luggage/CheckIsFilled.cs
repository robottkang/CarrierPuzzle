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
        GameObject.Find("");
    }

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
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
        if (Input.GetMouseButtonUp(0) == true &&
            transform.position.x > carrierSize.LimitMin.x &&
            transform.position.x < carrierSize.LimitMax.x &&
            transform.position.y > carrierSize.LimitMin.y &&
            transform.position.y < carrierSize.LimitMax.y)
        {
            width = (int)(transform.position.x - 0.5f - carrierSize.LimitMin.x);
            length = (int)(transform.position.y - 0.5f - carrierSize.LimitMin.y);
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
    }

    private void ResetColumn()
    {
        if (luggageScript.IsWrong == true)
        {
            gameManager.IsOnObject[width, length] = false;
            luggageScript.IsWrong = false;
        }
    }
}