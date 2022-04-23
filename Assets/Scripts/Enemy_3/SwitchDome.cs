using System.Collections;
using UnityEngine;

public class SwitchDome : MonoBehaviour
{
    [SerializeField] private GameObject _dome;
    [SerializeField] private Shooting _enemyShootingPoint;
    [SerializeField] private float _timeToOpen;
    [SerializeField] private float _spawningTime;
    [SerializeField] private float _timeToStartSpawning;
    [SerializeField] private int _countOfSpawningEnemy_4;
    private EnemyMovement _enemyMovement;
    private bool stoper;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        stoper = true;
        StartCoroutine(SpawningEnemies());
    }
    private void FixedUpdate()
    {
        if (stoper) _enemyMovement.Starting();
        else _enemyMovement.Stoping();
    }

    IEnumerator SpawningEnemies()
    {
        while (this.gameObject.activeSelf)
        {
            if (_enemyMovement.BoolDistanceToPlayer())  // проверка на расстояние до игрока
            {
                yield return new WaitForSeconds(_timeToStartSpawning);  // ожидание перед открытием купола

                stoper = false;                                         // остановка врага_3
                _dome.SetActive(true);                                  // открытие купола
                _dome.transform.position = transform.position;

                yield return new WaitForSeconds(_timeToOpen);           // ожидание перед спавном врагов_4

                for (int i = 0; i < _countOfSpawningEnemy_4; i++)       // спавн врагов_4
                {
                    yield return new WaitForSeconds(_spawningTime);
                    _enemyShootingPoint.SpawningObjects();
                }

                yield return new WaitForSeconds(_timeToOpen);           // ожидание после спавна врагов_4

                _dome.SetActive(false);                                 // закрытие купола

                stoper = true;                                          // продолжение движения врага_3
            }
        }
    }
}
