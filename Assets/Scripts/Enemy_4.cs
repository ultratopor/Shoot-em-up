using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        enemyMovement.Starting();
    }
}
