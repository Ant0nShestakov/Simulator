using System.Collections;
using UnityEngine;

public abstract class AbstractReservuar : Command
{
    public abstract float LiquidComponent { get; set; }
    public abstract float SecondComponent { get; set; }
    public abstract float FinishedProduct { get; set; }

    public sealed override float Value { get; set; }

    protected abstract void Loading();

    protected IEnumerator Cooking(float time)
    {
        while (SecondComponent > 0)
        {
            yield return new WaitForSecondsRealtime(time);
            Loading();
        }
    }
}