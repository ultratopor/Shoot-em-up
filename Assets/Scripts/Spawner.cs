using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Spawner : MonoBehaviour
{
    // префабы врагов
    [SerializeField] private GameObject _enemy_1;
    [SerializeField] private GameObject _enemy_2;
    [SerializeField] private GameObject _enemy_3;
    
    // общее количество врагов
    [SerializeField] private int _countOfEnemies;
    
    // точки спавна врагов
    [SerializeField] private Transform _point_1;   
    [SerializeField] private Transform _point_2;
    [SerializeField] private Transform _point_3;
    [SerializeField] private Transform _point_4;
    [SerializeField] private Transform _point_5;
    
    // массивы врагов
    [SerializeField] private List<GameObject> _enemies_1;
    [SerializeField] private List<GameObject> _enemies_2;
    [SerializeField] private List<GameObject> _enemies_3;

    // количество живых врагов на сцене
    private int enabledEnemiesOnScene=0;

    // количество врагов, добавляемых за раунд
    [SerializeField] private int _enemiesOnSceneCount;

    // время между добавлением врагов на сцену
    [SerializeField] private float _timeToAdd;

    // время между раундами
    private float waveTime=30f;

    // включение смены раундов
    private bool isWaveActive = false;


    // создание выключенных врагов на сцене
    private void Awake()
    {
        for (int i = 0; i < _countOfEnemies; i++)
        {
            GameObject enemyObject = Instantiate(_enemy_1);
            _enemies_1.Add(enemyObject);
            enemyObject.SetActive(false);
        }

        for (int i = 0; i < _countOfEnemies; i++)
        {
            GameObject enemyObject = Instantiate(_enemy_2);
            _enemies_2.Add(enemyObject);
            enemyObject.SetActive(false);
        }

        for (int i = 0; i < _countOfEnemies; i++)
        {
            GameObject enemyObject = Instantiate(_enemy_3);
            _enemies_3.Add(enemyObject);
            enemyObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (!isWaveActive)
        {
            if (enabledEnemiesOnScene == 0)
            {
                StartCoroutine(LoadWave());
            }
        }
    }

    // создание рандомной точки спавна врагов
    private Transform RandomisePoints()
    {
        int temp = Random.Range(1, 5);
        if (temp == 1) return _point_1;
        else if (temp == 2) return _point_2;
        else if (temp == 3) return _point_3;
        else if (temp == 4) return _point_4;
        else return _point_5;
    }

    // спавн врагов
    IEnumerator AddEnemy()
    {
        for (int i = 0; i < _enemiesOnSceneCount; i++)
        {
            _enemies_1[i].SetActive(true);
            _enemies_1[i].transform.position = RandomisePoints().position;
            enabledEnemiesOnScene++;
            yield return new WaitForSeconds(_timeToAdd);

            _enemies_2[i].SetActive(true);
            _enemies_2[i].transform.position = RandomisePoints().position;
            enabledEnemiesOnScene++;
            yield return new WaitForSeconds(_timeToAdd);

            _enemies_3[i].SetActive(true);
            _enemies_3[i].transform.position = RandomisePoints().position;
            enabledEnemiesOnScene++;
            yield return new WaitForSeconds(_timeToAdd);
        }

        isWaveActive = false;
    }

    // активация нового раунда
    IEnumerator LoadWave()
    {
        isWaveActive = true;
        _enemiesOnSceneCount += 5;
        _timeToAdd -= 0.1f;
        yield return new WaitForSeconds(waveTime);
        StartCoroutine(AddEnemy());
    }

    // уменьшение активных врагов на сцене
    public void KillEnemy()
    {
        enabledEnemiesOnScene--;
    }
}
