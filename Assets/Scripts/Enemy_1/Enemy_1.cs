using System.Collections;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    [SerializeField] private Shooting _shootingPoint;
    [SerializeField] [Range(2f, 5f)] private float _timeToShoot;
    [SerializeField] [Range(2f,10f)] private float _timeToTeleport;
    private EnemyMovement enemyMovement;
    private ActivateTeleport activateTeleport;
    private bool isShoot;
    private bool isTeleportActive;

    private void OnEnable()
    {
        isShoot = false;
        isTeleportActive = false;
    }

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        activateTeleport = GetComponent<ActivateTeleport>();
    }

    private void FixedUpdate()
    {
        enemyMovement.Starting();

        if (enemyMovement.BoolDistanceToPlayer())
        {
            if (!isShoot)
            {
                isShoot = true;
                StartCoroutine(Shooting());
            }

            if (!isTeleportActive)
            {
                isTeleportActive = true;
                StartCoroutine(EnableTeleport());
            }
        }
    }

    IEnumerator Shooting()  // выстрел врага
    {
        yield return new WaitForSeconds(_timeToShoot);
        _shootingPoint.SpawningObjects();
        isShoot = false;
    }

    IEnumerator EnableTeleport()  //активация телепорта
    {
        yield return new WaitForSeconds(_timeToTeleport);
        activateTeleport.OpenTeleport();
        isTeleportActive = false;
    }
}
