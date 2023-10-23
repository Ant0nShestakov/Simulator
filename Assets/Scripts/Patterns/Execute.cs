using UnityEngine;

//Вот это нужно обернуть в Command
public class Execute : MonoBehaviour
{
   // private Animator _animator;
    [field: SerializeField] public Command Command { get; private set; }

    private void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    public void Executing() 
    {
        //_animator.SetTrigger("Click");
        Command.Run();
    }
}
