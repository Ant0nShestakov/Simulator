using UnityEngine;

public class Execute : MonoBehaviour
{
   // private Animator _animator;
    [field: SerializeField] public Command Command { get; private set; }

    public void Executing() => Command.Run();
}
