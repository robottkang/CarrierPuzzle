using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject parentObject;
    private Vector3 mouseDefaultPosition;
    private Vector3 objectDefaultPosition;
    public Vector3 ObjectDefaultPosition => objectDefaultPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 offset;
    private Vector3 childObjectPosition;
    private bool isInMouse;

    private void Awake()
    {
        isInMouse = false;
    }

    private void Start()
    {
        objectDefaultPosition = transform.position; //오브젝트의 위치값 초기값 초기화
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if ((mainCamera.ScreenToWorldPoint(Input.mousePosition).x < childObjectPosition.x + 0.5f) &&
                (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > childObjectPosition.x - 0.5f) &&
                (mainCamera.ScreenToWorldPoint(Input.mousePosition).y < childObjectPosition.y + 0.5f) &&
                (mainCamera.ScreenToWorldPoint(Input.mousePosition).y > childObjectPosition.y - 0.5f) &&
                Input.GetMouseButtonDown(0) == true) //이 오브젝트의 자식 오브젝트 안에 마우스가 클릭된다면
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
                childObjectPosition = parentObject.transform.GetChild(i).position;
            }

            if (isInMouse && Input.GetMouseButtonUp(0) == true)
            {
                transform.position = new Vector3((int)mainCamera.ScreenToWorldPoint(Input.mousePosition).x - (int)(mainCamera.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x), (int)mainCamera.ScreenToWorldPoint(Input.mousePosition).y - (int)(mainCamera.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y), 0f);
                isInMouse = false;
            }
        }
    }
}