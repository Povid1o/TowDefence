using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Prefab of enemy")]
    public Enemy enemy;
    
    public Transform[] road;
    public List<Enemy> enemyList = new List<Enemy>();
    
    private bool _isWaveStarted = false;
    private int _targetEnemyCount;
    private int _spawnedEnemyCount;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void StartWave(int enemyCount)
    {
        _isWaveStarted = true;
        _targetEnemyCount = enemyCount;
        
        StartCoroutine(EnemySpawning());
    }
    
    private void CreateEnemy()
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity); //погуглить про (видео в дискорде)

        newEnemy.target = road;
        enemyList.Add(newEnemy);

        _spawnedEnemyCount++;
    }

    private IEnumerator EnemySpawning()
    {
        CreateEnemy();
        if (_spawnedEnemyCount >= _targetEnemyCount)
        {
            _isWaveStarted = false;
            _gameManager.EndWave();
        }
        yield return new WaitForSeconds(1);
        if (_isWaveStarted) StartCoroutine(EnemySpawning());
    }
}
