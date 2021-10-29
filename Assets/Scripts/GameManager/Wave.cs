using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveType
{
    Easy,
    Normal,
    Hard
}

[System.Serializable]
public class Wave 
{
    public string name = "Wave";
    public float brakeToNextWave = 10f;
    public int enemyCount = 0;

}
