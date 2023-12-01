using UnityEngine;

public abstract class Command : MonoBehaviour
{
    private PanelText[] _panelsText;

    public abstract float Value { get; set; }

    private void Start() => _panelsText = FindObjectsOfType<PanelText>();

    protected void UpdateOnDisplays()
    {
        foreach (var panelText in _panelsText) 
            panelText.UpdateInfo();
    }

    public virtual void Switch() { }

    public abstract void Run();
}