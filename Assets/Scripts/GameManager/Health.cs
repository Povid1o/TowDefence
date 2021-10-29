using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    protected float _health;

    public virtual void Increase(float value)
    {
        _health += value;
    }

    public virtual void Decrease(float value)
    {
        _health -= value;
    }
}
