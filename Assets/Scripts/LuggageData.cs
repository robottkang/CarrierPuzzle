using UnityEngine;

[CreateAssetMenu]
public class LuggageData : ScriptableObject
{
    [SerializeField] private Vector3 limitMax;
    [SerializeField] private Vector3 limitMin;

    public Vector3 LimitMax => limitMax;
    public Vector3 LimitMin => limitMin;
}