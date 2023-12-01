using UnityEngine;

public class Execute : MonoBehaviour
{
    private Animator _animator;

    [field: SerializeField] public Command Command { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Executing() => Command.Run();

    public void Switching() => Command.Switch();

    public void EnterAnimationClick() => _animator.SetBool("OnClick", true);

    public void ExitAnimationClick() => _animator.SetBool("OnClick", false);

}
