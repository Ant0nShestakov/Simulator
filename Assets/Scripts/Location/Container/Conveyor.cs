using System.Collections;
using UnityEngine;

public class Conveyor : Command
{
    [SerializeField] private float _dose;
    [SerializeField] private float _time;
    [SerializeField] private Reservuar _germes;

    public float Value { get; set; } = 0;

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

    private IEnumerator LoadToGermes()
    {
        while (Value > 0 )
        {
            yield return new WaitForSecondsRealtime(_time);
            Loading();
        }
    }

    public override void Run()  => StartCoroutine(LoadToGermes());
}
