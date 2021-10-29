using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTower:Health
{
    private Tower _tower;

    public HealthTower(float health, Tower tower)
    {
        _health = health;
        _tower = tower;
    }

    public override void Decrease(float value)
    {
        base.Decrease(value);
        if (_health <= 0) _tower.DestroyTower();
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);

    }
    
}
