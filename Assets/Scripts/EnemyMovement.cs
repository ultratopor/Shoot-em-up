using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distanceToPlayer;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // рассчёт дистанции до игрока
    public float CalcDistanseToPlayer()
    {
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;

        return distance;
    }

    public bool BoolDistanceToPlayer()
    {
        return (CalcDistanseToPlayer() <= _distanceToPlayer) ? true : false;
    }

    /// <summary>
    /// остановка движения врага
    /// </summary>
    public void Stoping()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    /// <summary>
    /// продолжение движения врага в сторону игрока
    /// </summary>
    public void Starting()
    {
        navMeshAgent.SetDestination(_player.position);
    }
}
