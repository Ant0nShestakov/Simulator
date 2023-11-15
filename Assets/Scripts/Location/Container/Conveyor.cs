using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Conveyor : Command
{
    [SerializeField] private float _dose;
    [SerializeField] private float _time;
    [SerializeField] private Reservuar _germes;

    private bool _isStart;

    public override float Value { get; set; } = 0;

    private void Loading()
    {
        if (Value < _dose)
        {
            _germes.SecondComponent += Value;
            Value = 0;
        }
        else
        {
            Value -= _dose;
            _germes.SecondComponent += _dose;
        }
    }

    private IEnumerator LoadToReservuar()
    {
        while (Value > 0 )
        {
            yield return new WaitForSecondsRealtime(_time);
            Debug.Log("UP");
            Loading();
            UpdateOnDisplays();
        }
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
