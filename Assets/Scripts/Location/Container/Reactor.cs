using UnityEngine;

public class Reactor : AbstractReservuar
{
    [SerializeField] private float _time;
    private bool _isWork;

    [field: SerializeField] public override float LiquidComponent { get; set; } = 1;

    [field: SerializeField] public override float SecondComponent { get; set; }

    [field: SerializeField] public override float FinishedProduct { get; set; }

    // Update is called once per frame
    private void Update()
    {
    }

    protected override void Loading()
    {
        FinishedProduct += 1;
        LiquidComponent = 0;
        SecondComponent = 0;
        Debug.Log("Reactor");
    }

    public override void Run()
    {
        if (!_isWork)
        {
            Debug.Log("Start");
            StartCoroutine(Cooking(_time));
            _isWork = true;
        }
    }
}
