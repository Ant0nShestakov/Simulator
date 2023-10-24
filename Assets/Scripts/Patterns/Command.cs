using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public abstract float Value { get; set; }
    public abstract void Run();
}