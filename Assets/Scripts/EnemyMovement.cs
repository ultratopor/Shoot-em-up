using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private Shooting _shootingPoint;
    [SerializeField] [Range(1, 20)] private float _distanceToPlayer;
    [SerializeField] [Range(2,6)] private float _timeToShoot;
    private float _temp;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _temp = _timeToShoot;
    }

    private void FixedUpdate()
    {
        _navMeshAgent.SetDestination(_target.position);
        
        #region Shooting
        Vector3 heading = _target.position - transform.position;
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
}
