using System.Collections;
using UnityEngine;

public class Conveyor : Command
{
    [SerializeField] private float _dose;
    [SerializeField] private float _waitTimeToWork;
    [SerializeField] private Reservuar _germes;

    private bool _isStart;

    [field:SerializeField]public override float Value { get; set; } = 0;

    private void Loading()
    {
        if (Value <= _germes.LiquidComponent)
            return;

        _germes.SecondComponent += _germes.LiquidComponent;
        Value -= _germes.SecondComponent;
        Debug.Log("true");
    }

    private IEnumerator LoadToReservuar()
    {
        yield return new WaitForSecondsRealtime(_waitTimeToWork);
        Loading();
        UpdateOnDisplays();
        _isStart = false;
    }

    public override void Run()
    {
        if (!_isStart)
        {
            StartCoroutine(LoadToReservuar());
            _isStart = true;
        }
    }
}
