using System.Collections;
using UnityEngine;

public class PumpManager : Command
{
    [SerializeField] private AbstractReservuar _pumpingObject;
    [SerializeField] private float _mass;

    private bool _isPumping;
    private bool _isWorking;

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
            _pumpingObject.LiquidComponent += _mass;
            yield return new WaitForSecondsRealtime(1);
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
