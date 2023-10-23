using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManger : MonoBehaviour
{
    [SerializeField] private Text _uiHelper;
    [SerializeField] private Text _uiInfoP;

    private Germes _reservuar;

    [field: SerializeField] public Text _uiTask { get; private set; }

    private void Start()
    {
        _reservuar = Singelton<Germes>.Instance;
    }

    private void LateUpdate()
    {
        _uiInfoP.text = $"Плотность:\n{_reservuar.LiquidComponent + _reservuar.SecondComponent}";
    }

    public void ActivateUIHelper(Command button)
    {
        _uiHelper.gameObject.SetActive(true);

        if (button is ManipulatorMovementManager)
            _uiHelper.text = "нажми Е чтобы запустить манипулятор";
        else if(button is PumpManager)
            _uiHelper.text = "нажми Е чтобы запустить насос";
        else if (button is Germes)
            _uiHelper.text = "нажми Е чтобы запустить процесс смешивания";
        else if (button is Reactor)
            _uiHelper.text = "нажми Е чтобы запустить реактор";
    }

    public void ActivateUIHelper()
    {
        _uiHelper.gameObject.SetActive(true);
        _uiHelper.text = "нажми Е для взаимодействия";
    }

    public void ResetState()
    {
        _uiHelper.gameObject.SetActive(false);
    }
}
