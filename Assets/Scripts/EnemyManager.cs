using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy;
    public Wave[] waves;
    private bool isEnded = false;
    private int curentSeconds = 0;
    private int targetSeconds = 0;

    public Transform[] road;
    public List<Enemy> enemyList = new List<Enemy>();

    public void StartWave(int seconds)
    {
        curentSeconds = 0;
        StartCoroutine(CoroutineSample());
        targetSeconds = seconds;
    }

    public void StartNextWave(int seconds, int Index)
    {
        StartCoroutine(CoroutineSample2(Index));
        curentSeconds = 0;
        StartCoroutine(CoroutineSample());
        targetSeconds = seconds;
    }

    private void CreateEnemy()
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity); //погуглить про (видео в дискорде)

        newEnemy.target = road;
        enemyList.Add(newEnemy);
    }

    public int GetCurrentSeconds()
    {
        return targetSeconds-curentSeconds; 
    }


    private IEnumerator CoroutineSample()
    {
        CreateEnemy();
        yield return new WaitForSeconds(1);
        curentSeconds++;
        if (curentSeconds == targetSeconds) isEnded = true;
        if(!isEnded) StartCoroutine(CoroutineSample());
    }

    private IEnumerator CoroutineSample2(int Index)
    {
        yield return new WaitForSeconds(waves[Index].brakeToNextWave);
    }
}
