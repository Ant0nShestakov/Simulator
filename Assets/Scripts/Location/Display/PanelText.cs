using TMPro;
using UnityEngine;

public class PanelText : MonoBehaviour
{
    [SerializeField] private AbstractReservuar _container;
    [SerializeField] private int _index;

    private TextMeshPro _textOnObject;
    private float[] _arrayProperties;

    // Start is called before the first frame update
    void Start()
    {
        _textOnObject = GetComponentInChildren<TextMeshPro>();
        _arrayProperties = new[] { _container.LiquidComponent, _container.SecondComponent, _container.FinishedProduct };
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        _textOnObject.text = $"{_arrayProperties[_index]}";
    }
}
