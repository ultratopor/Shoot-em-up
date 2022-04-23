using UnityEngine;
using System.Collections;

public class Enemy_4 : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    [SerializeField] private GameObject _enemy_4ExplosionArea;
    [SerializeField] private float _distanceToPlayer;
    [SerializeField] private float _timeToStop;
    private bool stoper;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        stoper = true;
    }

    private void FixedUpdate()
    {
        if (stoper) enemyMovement.Starting();
        else enemyMovement.Stoping();

        if(enemyMovement.CalcDistanseToPlayer()<=_distanceToPlayer)
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        stoper = false;
        yield return new WaitForSeconds(_timeToStop);
        _enemy_4ExplosionArea.SetActive(true);
        _enemy_4ExplosionArea.transform.position = transform.position;
        this.gameObject.SetActive(false);
    }
}
