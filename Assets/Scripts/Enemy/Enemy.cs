using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public Transform[] target;
    
    private HealthEnemy _health;
    private int _targetIndex = 0;
    
    private void Start()
    {
        _health = new HealthEnemy(10, this);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMouseDown()
    {
        _health.Decrease(5);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position =
            Vector3.MoveTowards(transform.position,
            new Vector3(target[_targetIndex].position.x, transform.position.y, target[_targetIndex].position.z),
            step);
        if (transform.position == new Vector3(target[_targetIndex].position.x, transform.position.y, target[_targetIndex].position.z))
        {
            _targetIndex++;
            if (_targetIndex == target.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}