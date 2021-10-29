using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public EnemyManager enemyManager;
    private TextMeshProUGUI _textTimer;

    private void Start()
    {
        _textTimer = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //_textTimer.text = enemyManager.GetCurrentSeconds().ToString();
    }
}
