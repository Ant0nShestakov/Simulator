using System.Collections;
using UnityEngine;

//Прибраться
public class ManipulatorMovementManager : Command
{
    [SerializeField] private float _speed;
    [SerializeField] private float _value = 100;
    [SerializeField] Transform _moveTransform;


    private Animator _animator;
    private bool isCollisionDown;
    private bool isCollisionLeft;
    private bool isStart;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
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
        if (other.TryGetComponent<Container>(out Container component))
        {
            _animator.SetTrigger("Grab");
            component.Value -= _value;
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

        if (other.TryGetComponent<Conveyor>(out Conveyor conveyor))
        {
            _animator.SetTrigger("Grab");
            conveyor.Value += _value;
            conveyor.Run();
            isCollisionDown = true;
            StopCoroutine(MoveDown());
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
            isStart = true;
        }
    }
}
