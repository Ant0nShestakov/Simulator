using System.Collections;
using UnityEngine;

public class PumpManager : Command
{
    [SerializeField] private AbstractReservuar _pumpingObject;
    [SerializeField] private float _waitTimeToWork;
    [SerializeField] private PanelText _panelText;

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

    private void Pump()
    {
        if (_pumpingObject is Reservuar && _pumpingObject.SecondComponent != 0)
        {
            _panelText.SetErrorStateOnDisplay(0);
            return;
        }
        _pumpingObject.LiquidComponent += Value;
    }

    private IEnumerator Pumping()
    {
        while (_isPumping)
        {
            _audioManager.Play();
            Pump();
            yield return new WaitForSecondsRealtime(_waitTimeToWork);
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
