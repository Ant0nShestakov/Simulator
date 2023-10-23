using UnityEngine;

public class PlayerMovemenManager : MonoBehaviour
{
    [SerializeField] private float _runingSpeed = 6;
    [SerializeField] private float _walkingSpeed = 2;

    private float _hInput;
    private float _vInput;
    private float _playerSpeed;

    private Animator _animator;
    private CharacterController _characterController;
    private MovenetState _state;
    private Vector3 _direction;

    public RunningState RuningState = new RunningState();
    public WalkingState WalkingState = new WalkingState();

    public Animator Animator { get => _animator; }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();

        _state = WalkingState;
        _playerSpeed = _walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        _direction = this.transform.forward * _vInput + this.transform.right * _hInput;

        _characterController.Move(_direction.normalized * _playerSpeed  * Time.deltaTime);

        _animator.SetFloat("hInput", _hInput);
        _animator.SetFloat("vInput", _vInput);

        _state.UpdateState(this);
    }


    public void SwitchState(MovenetState state)
    {
        _state = state;
        _state.EnterState(this);
    }

    public void SetWalkSpeedState()
    {
        _playerSpeed = _walkingSpeed;
    }

    public void SetRunSpeedState()
    {
        _playerSpeed = _runingSpeed;
    }
}
