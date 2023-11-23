using System.Collections;
using UnityEngine;

public class ManipulatorMovementManager : Command
{
    [SerializeField] private float _speed;
    [SerializeField] Transform _moveTransform;

    private Animator _animator;
    private AudioManager _audioManager;
    private bool isCollisionDown;
    private bool isCollisionLeft;
    private bool isStart;

    [field: SerializeField] public override float Value { get; set; } = 100;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioManager = GetComponentInChildren<AudioManager>();
    }

    private IEnumerator MoveDown()
    {
        while (!isCollisionDown)
        {
            _moveTransform.Translate(Vector3.down * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MoveUp()
    {
        while (isCollisionDown)
        {
            _moveTransform.Translate(Vector3.up * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MoveLeft()
    {
        while (!isCollisionLeft)
        {
            _moveTransform.Translate(Vector3.left * 2 * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MoveRight()
    {
        while (isCollisionLeft)
        {
            _moveTransform.Translate(Vector3.right * 2 * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Command>(out Command component))
        {
            _animator.SetTrigger("Grab");
            if(component is Container)
                component.Value -= this.Value;
            else if(component is Conveyor) 
            {
                Debug.Log("This conveyor");
                component.Value += this.Value;
                UpdateOnDisplays();
            }
            isCollisionDown = true;
            StopCoroutine(MoveDown());
            return;
        }

        if (other.gameObject.CompareTag("RightTriggerY") && isCollisionDown)
        {
            isCollisionDown = false;
            StopCoroutine(MoveUp());

            isCollisionLeft = false;
            StartCoroutine(MoveLeft());
            return;
        }

        if (other.gameObject.CompareTag("LeftTriggerX") && !isCollisionLeft)
        {
            isCollisionLeft = true;
            StopCoroutine(MoveLeft());

            isCollisionDown = false;
            StartCoroutine(MoveDown());
            return;
        }

        if (other.gameObject.CompareTag("LeftTriggerY") && isCollisionDown)
        {
            isCollisionDown = false;
            StopCoroutine(MoveUp());

            isCollisionLeft = true;
            StartCoroutine(MoveRight());
            return;
        }

        if (other.gameObject.CompareTag("RightTriggerX") && isCollisionLeft)
        {
            isCollisionLeft = false;
            StopCoroutine(MoveRight());
            _audioManager.Stop();
            isStart = false;
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Command>(out Command component))
        {
            if (IsAnimationCanceled("Ended"))
                StartCoroutine(MoveUp());
            return;
        }
    }

    private bool IsAnimationCanceled(string AnimationName)
    {
        if (AnimationName == null)
            return false;
        var check = _animator.GetCurrentAnimatorStateInfo(0);
        return check.IsName(AnimationName);
    }

    public override void Run()
    {
        if (!isStart)
        {
            StartCoroutine(MoveDown());
            _audioManager.Play();
            isStart = true;
        }
    }
}