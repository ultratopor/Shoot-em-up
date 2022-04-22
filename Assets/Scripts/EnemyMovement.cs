using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private NavMeshAgent navMeshAgent;
    [SerializeField] [Range(1, 20)] private float _distanceToPlayer;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // рассчёт дистанции до игрока
    public bool CalcDistanseToPlayer()
    {
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;

        return (distance<=_distanceToPlayer)?true:false;
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
