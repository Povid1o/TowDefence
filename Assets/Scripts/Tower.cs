using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public HealthTower health;
    public List<Enemy> enemyList = new List<Enemy>();
    private Transform target;
    bool isDead = false;

    private void FindTarget()
    {
        //float x = Vector3.Distance(new Vector3(0, 0, 0), transform.position);
        float minDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemyList)
        {
            if (!enemy) return;
            if (minDistance > Vector3.Distance(transform.position, enemy.transform.position))
            {
                minDistance = Vector3.Distance(transform.position, enemy.transform.position);
                target = enemy.transform;
            }
        }
    }
    
    private void Update()
    {
        TurnToEnemy();
    }

    private void TurnToEnemy()
    {
        FindTarget();
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void Start()
    {
        health = new HealthTower(5, this);
    }

    private void TakeAttack()
    {
        health.Decrease(5);
        print("Take attack!");
    }

    public void DestroyTower()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeAttack();
    }
}
