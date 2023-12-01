using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private string _name;
    [SerializeField] private ErrorsOnLocation _errorOnLocation;
    
    private TextMeshPro _textOnObject;
    private Conveyor _conveyor;
    private float[] _properties;

    [field: SerializeField] public AbstractReservuar Container { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        _textOnObject = GetComponentInChildren<TextMeshPro>();
        UpdateInfo();
    }

    public void SetErrorStateOnDisplay(int indexOfError)
    {
        if (indexOfError > _errorOnLocation.Erros.Length - 1)
            return;
        Debug.Log("Y");
        _textOnObject.text = _errorOnLocation.Erros[indexOfError];
    }

    public void UpdateInfo() 
    {
        if (Container == null)
        {
            if(_conveyor == null)
                _conveyor = Singelton<Conveyor>.Instance;
            _textOnObject.text = $"{_name}: {_conveyor.Value}";
        }
        else
        {
            _properties = new[] { Container.LiquidComponent, Container.SecondComponent, Container.FinishedProduct };
            _textOnObject.text = $"{Container.Name}\n({_name}): {_properties[_index]}";
        }
    }
}
