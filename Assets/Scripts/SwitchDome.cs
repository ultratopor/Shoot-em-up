using System.Collections;
using UnityEngine;

public class SwitchDome : MonoBehaviour
{
    [SerializeField] private GameObject _dome;
    [SerializeField] private Shooting _enemyShootingPoint;
    [SerializeField] private float _timeToOpen;
    [SerializeField] private float _timeToClose;
    [SerializeField] private float _timeToStartSpawning;
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        if (_enemyMovement.CalcDistanseToPlayer())
        {
            _enemyMovement.Stoping();
            _dome.SetActive(true);
            StartCoroutine(SpawningEnemies());
            
            _enemyMovement.Starting();
        }
    }

    IEnumerator SpawningEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Spawning");
            _enemyShootingPoint.SpawningObjects();
        }
        StartCoroutine(ClosingDome());
    }

    IEnumerator ClosingDome()
    {
        yield return new WaitForSeconds(2f);
        _dome.SetActive(false);
        Debug.Log("Starting");
        _enemyMovement.Starting();
    }
}
