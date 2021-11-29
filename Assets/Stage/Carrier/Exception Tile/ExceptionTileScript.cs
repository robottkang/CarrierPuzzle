using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionTileScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private int width, length;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        width = (int)(transform.position.x - (gameManager.Carriers[gameManager.stageNumber].transform.position.x - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.x / 2)));
        length = (int)(transform.position.y - (gameManager.Carriers[gameManager.stageNumber].transform.position.y - (gameManager.Carriers[gameManager.stageNumber].transform.lossyScale.y / 2)));
    }

    void Update()
    {
        gameManager.IsOnObject[width, length] = true;
    }
}
