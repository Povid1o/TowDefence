using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI textTimer;
    public EnemyManager enemySpawner;


    private void Update()
    {
        textTimer.text = enemySpawner.GetCurrentSeconds().ToString();
    }
}
