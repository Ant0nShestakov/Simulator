using System;
using System.Collections;
using UnityEngine;

public class Reservuar : AbstractReservuar
{
    [SerializeField] private Reactor _reactor;
    [SerializeField] private float _totalP;
    [SerializeField] private float _time;

    private bool _isWork;
    private float P;

    [field: SerializeField] public override float LiquidComponent { get; set; } 
    [field: SerializeField] public override float SecondComponent { get; set; }
    [field: SerializeField] public override float FinishedProduct { get; set; } = 0;

    private void Update()
    {
        P = LiquidComponent + SecondComponent;
    }

    protected override void Loading()
    {
        SecondComponent = 0;
        LiquidComponent = 0;
        FinishedProduct += 1;
        _reactor.SecondComponent += FinishedProduct;
        _isWork = false;
        FinishedProduct = 0;
        UpdateOnDisplays();
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
