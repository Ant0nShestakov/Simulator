using System.Collections;
using UnityEngine;

public class PumpManager : Command
{
    [SerializeField] private AbstractReservuar _pumpingObject;
    [SerializeField] private float _time;
    private bool _isPumping;
    private bool _isWorking;
    private AudioManager _audioManager;

    [field: SerializeField] public override float Value { get; set; }

    private void Awake()
    {
        _audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && _isPumping)
        {
            _isPumping = false;
            _audioManager.Stop();
            StopCoroutine(Pumping());
        }
    }

    private IEnumerator Pumping()
    {
        while (_isPumping)
        {
            _audioManager.Play();
            yield return new WaitForSecondsRealtime(_time);
            _pumpingObject.LiquidComponent += Value;
            UpdateOnDisplays();
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
