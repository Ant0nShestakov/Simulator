using UnityEngine;

//��� ��� ����� �������� � Command
public class Execute : MonoBehaviour
{
    [field: SerializeField] public Command Command { get; private set; }

    public void Executing() => Command.Run();
}
