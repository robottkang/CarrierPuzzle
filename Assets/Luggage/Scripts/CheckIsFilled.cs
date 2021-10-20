using UnityEngine;

public class CheckIsFilled : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] LuggageScript luggageScript;
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
            if (transform.position.x < gameManager.CarrierData.transform.position.x + (gameManager.CarrierData.transform.lossyScale.x / 2) &&
                transform.position.x > gameManager.CarrierData.transform.position.x - (gameManager.CarrierData.transform.lossyScale.x / 2) &&
                transform.position.y < gameManager.CarrierData.transform.position.y + (gameManager.CarrierData.transform.lossyScale.y / 2) &&
                transform.position.y > gameManager.CarrierData.transform.position.y - (gameManager.CarrierData.transform.lossyScale.y / 2))
            {
                width = (int)(transform.position.x - (gameManager.CarrierData.transform.position.x - (gameManager.CarrierData.transform.lossyScale.x / 2)));
                length = (int)(transform.position.y - (gameManager.CarrierData.transform.position.y - (gameManager.CarrierData.transform.lossyScale.y / 2)));
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