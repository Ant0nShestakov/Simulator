using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Reservuar : AbstractReservuar
{
    [SerializeField] private Reactor[] _reactor;
    [SerializeField] private float _totalP;
    [SerializeField] private float _time;
    [SerializeField] private PanelText _panelText;

    private bool _isWork;
    private bool _isSwitch;
    private float P;

    private Reactor _currentReactor;

    [field: SerializeField] public override string Name{ get; set; }
    [field: SerializeField] public override float LiquidComponent { get; set; } 
    [field: SerializeField] public override float SecondComponent { get; set; }
    [field: SerializeField] public override float FinishedProduct { get; set; } = 0;

    private void Awake()
    {
        _currentReactor = _reactor[0];
    }

    private void Update()
    {
        P = LiquidComponent + SecondComponent;
    }

    protected override void Loading()
    {
        SecondComponent = 0;
        LiquidComponent = 0;
        _currentReactor.SecondComponent += 1;
        _isWork = false;
        UpdateOnDisplays();
    }

    private IEnumerator SwitchReactor()
    {
        yield return new WaitForSecondsRealtime(3);
        while (_isSwitch)
        {
            if (_currentReactor == _reactor[0])
            {
                _currentReactor = _reactor[1];
                if (_panelText.Container is Reactor)
                    _panelText.Container = _reactor[1];
            }
            else if (_currentReactor == _reactor[1])
            {
                _currentReactor = _reactor[0];
                if (_panelText.Container is Reactor)
                    _panelText.Container = _reactor[0];
            }
            UpdateOnDisplays();
            _isSwitch = false;
        }
    }

    public override void Switch()
    {
        if (!_isSwitch)
        {
            _isSwitch = true;
            StartCoroutine(SwitchReactor());
        }
    }

    public override void Run()
    {
        if (!_isWork && P >= _totalP)
        {
            Debug.Log("Start");
            StartCoroutine(Cooking(_time));
            _isWork = true;
        }
    }
}
