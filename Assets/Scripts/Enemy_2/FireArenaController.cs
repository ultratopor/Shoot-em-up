using System.Collections;
using UnityEngine;

public class FireArenaController : MonoBehaviour
{
    private Shooting shooting;
    [SerializeField] private float _timeToShootFireBall;
    [SerializeField] private int _countOfBalls;

    private void Awake()
    {
        shooting = GetComponent<Shooting>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartShootingFireBalls());
    }

    private float CalcTimeOfShooting() // рассчёт времени между выстрелами
    {
        return Random.Range(0, _timeToShootFireBall);
    }

    IEnumerator StartShootingFireBalls()  
    {
        for (int i = 0; i < _countOfBalls; i++)
        {
            shooting.SpawningObjects();
            yield return new WaitForSeconds(CalcTimeOfShooting());
            if (i == _countOfBalls - 1) this.gameObject.SetActive(false);
        }
    }
}
