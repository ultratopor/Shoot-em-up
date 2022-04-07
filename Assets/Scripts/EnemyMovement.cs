using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private Shooting _shootingPoint;
    [SerializeField] [Range(1, 20)] private float _distanceToPlayer;
    [SerializeField] [Range(2,6)] private float _timeToShoot;
    [SerializeField] private bool _isEnemyShoot;
    private float _temp;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _temp = _timeToShoot;
    }

    private void FixedUpdate()
    {
        #region Shooting  условия выстрела врага 
        if (_isEnemyShoot)
        {
            if (CalcDistanseToPlayer() <= _distanceToPlayer)
            {
                if (_temp < 0)
                {
                    _temp = _timeToShoot;
                    _shootingPoint.Fire();
                }
            }
        }
        #endregion
    }

    public float CalcDistanseToPlayer()
    {
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;
        return distance;
    }

    public float SetDistanseToPlayer()
    {
        return _distanceToPlayer;
    }

    /// <summary>
    /// остановка движения врага
    /// </summary>
    public void Stoping()
    {
        _navMeshAgent.SetDestination(transform.position);
    }
    /// <summary>
    /// продолжение движения врага в сторону игрока
    /// </summary>
    public void Starting()
    {
        _navMeshAgent.SetDestination(_player.position);
        _temp -= Time.deltaTime;
    }
}
