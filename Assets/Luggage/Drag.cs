using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private StageData carrierSize;
    [SerializeField] private LuggageData luggageData;
    private Vector3 objectMinVector;
    private Vector3 objectMaxVector;
    private Vector3 mouseDefaultPosition;
    private Vector3 objectDefaultPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 offset;
    private bool isInMouse;

    private void Start()
    {
        isInMouse = false;
        objectDefaultPosition = transform.position; //오브젝트의 위치값 초기값 초기화
        objectMinVector = new Vector3(transform.position.x, transform.position.y, 0f);
        objectMaxVector = new Vector3(transform.position.x + luggageData.LimitMax.x, transform.position.y + luggageData.LimitMax.y, 0f);
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        if ((mainCamera.ScreenToWorldPoint(Input.mousePosition).x < objectMaxVector.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > objectMinVector.x) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y < objectMaxVector.y) &&
            (mainCamera.ScreenToWorldPoint(Input.mousePosition).y > objectMinVector.y) &&
            Input.GetMouseButtonDown(0) == true) //이 오브젝트 안에 마우스가 클릭된다면
        {
            mouseDefaultPosition = mouseWorldPosition; //마우스의 위치 초기값 초기화
            objectDefaultPosition = transform.position; //위치 디폴트값 초기화
            isInMouse = true;
        }

        if (isInMouse && Input.GetMouseButton(0) == true)
        {
            offset = mouseDefaultPosition - mouseWorldPosition;
            transform.position = new Vector3(objectDefaultPosition.x - offset.x, objectDefaultPosition.y - offset.y, 0f);
        }
        else
        {
            objectMinVector = new Vector3(transform.position.x, transform.position.y, 0f);
            objectMaxVector = new Vector3(transform.position.x + luggageData.LimitMax.x, transform.position.y + luggageData.LimitMax.y, 0f);
        }

        if (isInMouse && Input.GetMouseButtonUp(0) == true)
        {
            transform.position = new Vector3((int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x - (int)(mainCamera.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x), (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y - (int)(mainCamera.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y), 0f);
            isInMouse = false;
        }
    }
}