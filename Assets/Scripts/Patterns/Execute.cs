using UnityEngine;

public class Execute : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    [field: SerializeField] public Command Command { get; private set; }

    public void Executing() => Command.Run();

    public void Switching() => Command.Switch();

    public void EnterAnimationClick() => _animator.SetBool("OnClick", true);

    public void ExitAnimationClick() => _animator.SetBool("OnClick", false);

}
