using UnityEngine;

[CreateAssetMenu(fileName = "ErrorsOnLocation", menuName= "ScritableObjects/ErrorsOnLocation")]
public class ErrorsOnLocation : ScriptableObject
{
    [field: SerializeField] public string[] Erros { get; private set; }
}
