using System.Collections;
using UnityEngine;

public class PumpManager : Command
{
    [SerializeField] private AbstractReservuar _pumpingObject;
    [SerializeField] private float _time;
    private bool _isPumping;
    private bool _isWorking;

    [field: SerializeField] public override float Value { get; set; }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            _isPumping = false;
            StopCoroutine(Pumping());
        }
    }

    private IEnumerator Pumping()
    {
        while (_isPumping)
        {
            _pumpingObject.LiquidComponent += Value;
            UpdateOnDisplays();
            yield return new WaitForSecondsRealtime(_time);
        }
        _isWorking = false;
    }

    public override void Run()
    {
        if (!_isWorking)
        {
            _isPumping = true;
            _isWorking = true;
            StartCoroutine(Pumping());
        }
    }
}
