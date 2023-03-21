using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private int _indexCurrentWave = 0;
    private float _timeAfterLastWave;
    private int _countSpawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChenged;

    private void Start()
    {
        SetWave(_indexCurrentWave);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastWave += Time.deltaTime;
        if(_timeAfterLastWave >= _currentWave.Delay)
        {
            InitialiateEnemy();
            _countSpawned++;
            _timeAfterLastWave = 0;
            EnemyCountChenged?.Invoke(_countSpawned, _currentWave.Count);
        }

        if(_currentWave.Count <= _countSpawned)
        {
            if(_waves.Count > _indexCurrentWave + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private void InitialiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dyuing += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChenged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dyuing -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }

    public void NextVawe()
    {
        SetWave(_indexCurrentWave++);
        _countSpawned = 0;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
