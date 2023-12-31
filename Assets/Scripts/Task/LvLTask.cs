using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName ="ScritableObjects/Task")]
public class LvLTask : ScriptableObject
{
    [field: SerializeField] public  string FirstTask { get; private set; }
    [field: SerializeField] public string FirstTaskDialog { get; private set; }
    [field: SerializeField] public int FirstTaskValue { get; private set; }

    [field: SerializeField] public  string SecondTask { get; private set; }
    [field: SerializeField] public int SecondTaskValue { get; private set; }
    [field: SerializeField] public string SecondTaskDialog { get; private set; }

    [field: SerializeField] public  string ThridTask { get; private set; }
    [field: SerializeField] public int ThridTaskValue { get; private set; }
    [field: SerializeField] public string ThridTaskDialog { get; private set; }

    [field: SerializeField] public string FourthTask { get; private set; }
    [field: SerializeField] public int FourthTaskValue { get; private set; }
    [field: SerializeField] public string FourthTaskDialog { get; private set; }

    [field: SerializeField] public string FiveTask { get; private set; }
    [field: SerializeField] public int FiveTaskValue { get; private set; }
    [field: SerializeField] public string FiveTaskDialog { get; private set; }

    [field: SerializeField] public string SixTask { get; private set; }
    [field: SerializeField] public int SixTaskValue { get; private set; }
    [field: SerializeField] public string SixTaskDialog { get; private set; }
}
