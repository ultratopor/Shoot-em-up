using System.Collections;
using UnityEngine;

public class SwitchDome : MonoBehaviour
{
    [SerializeField] private GameObject _dome;
    [SerializeField] private Shooting _enemyShootingPoint;
    [SerializeField] private float _timeToOpen;
    [SerializeField] private float _timeToStartSpawning;
    private float tempToOpen;
    private float tempToStartSpawning;
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        tempToOpen = _timeToOpen;
        tempToStartSpawning = _timeToStartSpawning;
    }

    private void FixedUpdate()
    {
        if (_enemyMovement.CalcDistanseToPlayer()<=_enemyMovement.SetDistanseToPlayer())
        {
            tempToOpen -= Time.deltaTime;

            if (tempToOpen <= 0)
            {
                _enemyMovement.Stoping();
                _dome.SetActive(true);
                tempToStartSpawning -= Time.deltaTime;
                if (tempToStartSpawning <= 0)
                {
                    StartCoroutine(SpawningEnemies());
                }
            }
            else _enemyMovement.Starting();
        }
    }

    IEnumerator SpawningEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Spawning");
            _enemyShootingPoint.SpawningObjects();
            _enemyShootingPoint.IncreasingOrderBullet();
        }
        StartCoroutine(ClosingDome());
    }

    IEnumerator ClosingDome()
    {
        yield return new WaitForSeconds(2f);
        _dome.SetActive(false);
        tempToStartSpawning = _timeToStartSpawning;
        tempToOpen = _timeToOpen;
        Debug.Log("Starting");
        _enemyMovement.Starting();
    }
}
