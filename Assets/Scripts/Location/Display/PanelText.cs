using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private string _name;
    
    private TextMeshPro _textOnObject;
    private float[] _properties;
    private Conveyor _conveyor;

    [field: SerializeField] public AbstractReservuar Container { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _textOnObject = GetComponentInChildren<TextMeshPro>();
        UpdateInfo();
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
