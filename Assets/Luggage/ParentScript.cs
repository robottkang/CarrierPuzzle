using UnityEngine;

public class ParentScript : MonoBehaviour
{
    [SerializeField] private GameObject line;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(line, new Vector3(transform.GetChild(i).position.x + 0.5f, transform.GetChild(i).position.y + 0.5f, 0f), Quaternion.identity);
        }
    }

    private void Update()
    {

    }
}