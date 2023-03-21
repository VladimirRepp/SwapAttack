using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _buttonNextWave;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _buttonNextWave.onClick.AddListener(OnButtonNextWaveClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _buttonNextWave.onClick.RemoveListener(OnButtonNextWaveClick);
    }

    public void OnAllEnemySpawned()
    {
        _buttonNextWave.gameObject.SetActive(true);
    }

    public void OnButtonNextWaveClick()
    {
        _spawner.NextVawe();
        _buttonNextWave.gameObject.SetActive(false);
    }
}
