using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Waves propeties")]
    public EnemyManager enemyManager;
    public Wave[] waves;

    private int _index = 0;
    private bool _levelStarted = false;
    
    private float _targetBreakTime;
    private float _currentBreakTime;

    public void LaunchWave()
    {
        if (_levelStarted) return;
        
        enemyManager.StartWave(waves[_index].enemyCount);
        _levelStarted = true;
    }

    public void EndWave()
    {
        _levelStarted = false;
        _targetBreakTime = waves[_index].brakeToNextWave;
        _currentBreakTime = 0;
        _index++;
        
        StartCoroutine(Break());
    }

    // ReSharper disable once FunctionRecursiveOnAllPaths
    private IEnumerator Break()
    {
        if (_targetBreakTime <= _currentBreakTime)
        {
            LaunchWave();
            StopCoroutine(Break());
        }
        _currentBreakTime++;
        yield return new WaitForSeconds(1);
        StartCoroutine(Break());
    }
}
