using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) _health.TakeDamage(1);
    }
}
