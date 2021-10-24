using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy: Health
{
    private Enemy _enemy;

    public HealthEnemy(float health, Enemy enemy)
    {
        _health = health;
        _enemy = enemy;
    }

    public override void Decrease(float value)
    {
        base.Decrease(value);
        if (_health <= 0) Death();
    }

    public void Death()
    {
        _enemy.Death();
    }
}
