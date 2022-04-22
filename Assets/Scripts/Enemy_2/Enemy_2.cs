using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    [SerializeField] private GameObject _shootingPoint;
    [SerializeField] [Range(2f, 5f)] private float _timeToShoot;
    [SerializeField] [Range(5f, 10f)] private float _timeToShootFireBullet;
    [SerializeField] [Range(0, 3f)] private float _waitingFireBullet;
    private EnemyMovement enemyMovement;
    private bool isShoot;
    private bool isShootFireBullet;

    private void OnEnable()
    {
        isShoot = false;
        isShootFireBullet = false;
    }

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        if(!isShootFireBullet) enemyMovement.Starting();

        if (enemyMovement.CalcDistanseToPlayer())
        {
            if (!isShoot)
            {
                isShoot = true;
                StartCoroutine(Shooting());
            }

            if (!isShootFireBullet)
            {
                isShootFireBullet = true;
                StartCoroutine(ShootingFireBullet());
            }
        }
    }

    IEnumerator Shooting()  // выстрел врага
    {
        yield return new WaitForSeconds(_timeToShoot);
        _shootingPoint.GetComponent<Shooting>().SpawningObjects();
        isShoot = false;
    }

    IEnumerator ShootingFireBullet()  // выстрел Fire Bullet
    {
        yield return new WaitForSeconds(_timeToShootFireBullet);
        enemyMovement.Stoping();      // оствновка перед выстрелом
        isShoot = true;
        yield return new WaitForSeconds(_waitingFireBullet);  // ожидание выстрела
        _shootingPoint.GetComponent<FireBulletController>().ShootFireBullet();  // выстрел
        yield return new WaitForSeconds(_waitingFireBullet);    // ожидание после выстрела
        isShootFireBullet = false;
        isShoot = false;
    }
}
