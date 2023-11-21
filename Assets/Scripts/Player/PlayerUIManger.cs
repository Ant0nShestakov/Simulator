using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManger : MonoBehaviour
{
    [SerializeField] private Text _uiHelper;
    [SerializeField] private Text _uiInfoP;

    private Reservuar _reservuar;

    [field: SerializeField] public Text _uiTask { get; private set; }

    private void Start()
    {
        _reservuar = Singelton<Reservuar>.Instance;
    }

    private void LateUpdate()
    {
        _uiInfoP.text = $"�����:\n{_reservuar.LiquidComponent + _reservuar.SecondComponent} ��";
    }

    public void ActivateUIHelper(Command button)
    {
        _uiHelper.gameObject.SetActive(true);
        if (button is ManipulatorMovementManager)
            _uiHelper.text = "����� � ����� ��������� �����������";
        else if(button is PumpManager)
            _uiHelper.text = "����� � ����� ��������� �����";
        else if (button is Reservuar)
            _uiHelper.text = "����� � ����� ��������� ������� ����������\n����� R ����� ������� �������";
        else if (button is Reactor)
            _uiHelper.text = "����� � ����� ��������� �������";
        else if (button is Conveyor)
            _uiHelper.text = "����� � ����� ��������� ��������";
    }

    public void ActivateUIHelper()
    {
        _uiHelper.gameObject.SetActive(true);
        _uiHelper.text = "����� � ��� ��������������";
    }

    public void ResetState()
    {
        _uiHelper.gameObject.SetActive(false);
    }
}
