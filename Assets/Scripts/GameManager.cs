using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Waves propeties")]
    public EnemyManager enemyManager;
    public Wave[] waves;
    public Tower _tower;
    public int time = 0;
    public float waitTime = 0;


    private int Index = 0;

    private bool levelStarted = false;

    public void StartLevel()
    {
        time = waves[Index].enemyCount;
        if (levelStarted) return;
        enemyManager.StartWave(time);
        levelStarted = true;
        //спросить про ошибку или подумать насчёт загрузки одного метода после другого
        NextWaveIndex();
        enemyManager.StartNextWave(time, Index);
    }


    private void Update()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        if (enemyManager.enemyList == null) return;
        _tower.enemyList = enemyManager.enemyList;

    }

    private void NextWaveIndex()
    {
        Index++;
        print(Index);
    }

    public void LaunchNextWave()
    {

    }

    public void LooseGame()
    {

    }

    public void WinGame()
    {
        
    }

    private IEnumerator CoroutineSample()
    {
        yield return new WaitForSeconds(waitTime);
    }

}
