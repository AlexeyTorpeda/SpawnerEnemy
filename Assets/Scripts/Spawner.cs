using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BlopBot _blopBot;
    [SerializeField] private Vector2 _firstPosition;
    [SerializeField] private float _interval;

    private float _minPosition = -6;
    private float _maxPosition = 6;
    private int _countOfEnemies = 5;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForIntervalSeconds = new WaitForSeconds(_interval);

        for (int i = 0; i < _countOfEnemies; i++)
        {
            Instantiate(_blopBot, _firstPosition, Quaternion.identity);
            _firstPosition.x += Random.Range(_minPosition, _maxPosition);
            yield return waitForIntervalSeconds;
        }
    }
}