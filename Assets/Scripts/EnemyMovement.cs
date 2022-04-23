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

    // ������� ��������� �� ������
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
    /// ��������� �������� �����
    /// </summary>
    public void Stoping()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    /// <summary>
    /// ����������� �������� ����� � ������� ������
    /// </summary>
    public void Starting()
    {
        navMeshAgent.SetDestination(_player.position);
    }
}
