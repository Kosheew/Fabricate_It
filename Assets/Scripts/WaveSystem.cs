using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemys;

    [SerializeField] private int _currentWave;

    [SerializeField] private float _startDelay;

    [SerializeField] private float _currentTime;

    [SerializeField] private int _countEnemy;
    private void Start()
    {
        _currentWave = 0;

        StartCoroutine(Wave(_startDelay));
    }

    IEnumerator Wave(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            yield return new WaitForSeconds(_currentTime);

            for(int i =0; i < _countEnemy; i++)
            {
                int randomEnemy = Random.Range(0, _enemys.Length);
                Instantiate(_enemys[randomEnemy], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }

            _currentTime -= 5f;
            if (_currentTime <= 10) _currentTime = 10f;

            _currentWave++;

            if(_currentTime >= 18)
            {

            }
        }
    }
}
