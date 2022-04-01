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
    private float _temp;
    private bool _stop=true;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _temp = _timeToShoot;
    }

    private void FixedUpdate()
    {
        if (_stop)
        {
            _navMeshAgent.SetDestination(_player.position);
        }
        else
        {
            _navMeshAgent.SetDestination(transform.position);
        }
        
        
        #region Shooting
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;

        _temp -= Time.deltaTime;

        if(distance<_distanceToPlayer)
        {
            if(_temp<0)
            {
                _temp = _timeToShoot;
                _shootingPoint.Fire();
            }
        }
        #endregion
    }

    public void Stoping()
    {
        _stop = false;
    }

    public void Starting()
    {
        _stop = true;
    }
}
