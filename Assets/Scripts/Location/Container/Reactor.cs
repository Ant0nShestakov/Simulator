using UnityEngine;

public class Reactor : AbstractReservuar
{
    [SerializeField] private float _waitTimeToWork;

    private bool _isWork;
    private AudioManager _audioManager;

    [field: SerializeField] public override string Name { get; set; }
    [field: SerializeField] public override float LiquidComponent { get; set; } = 1;
    [field: SerializeField] public override float SecondComponent { get; set; }
    [field: SerializeField] public override float FinishedProduct { get; set; }

    private void Awake()
    {
        _audioManager = GetComponent<AudioManager>();
    }

    protected override void StartAudio() => _audioManager.Play();

    protected override void StopAudio() => _audioManager.Stop();

    protected override void Loading()
    {
        FinishedProduct += 1;
        LiquidComponent = 0;
        SecondComponent = 0;
    }

    public override void Run()
    {
        if (!_isWork)
        {
            StartCoroutine(Cooking(_waitTimeToWork));
            _isWork = true;
        }
    }
}
