using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform[] target;
    private int Index = 0;
    public HealthEnemy health;
    private bool enemyIsDead=false;

    public static object enemy { get; internal set; }

    private void Start()
    {
        health = new HealthEnemy(10, this);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMouseDown()
    {
        health.Decrease(5);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position =
            Vector3.MoveTowards(transform.position,
            new Vector3(target[Index].position.x, transform.position.y, target[Index].position.z),
            step);
        if (transform.position == new Vector3(target[Index].position.x, transform.position.y, target[Index].position.z))
        {
            Index++;
            if (Index == target.Length)
            {
                Destroy(gameObject);
                enemyIsDead = true;
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}