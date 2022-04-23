using UnityEngine;

public class Health : MonoBehaviour
{
    // ��������
    [SerializeField] [Range(1,4)] private int _currentHealth;

    // �������� � Enemy_1, Enemy_2, Enemy_3
    [SerializeField] private bool _enemyFromSpawn;

    // �������� � Enemy_1, Enemy_2, Enemy_3
    [SerializeField] private Spawner _game;

    private bool isAlive=true;

    private ActorView actorView;

    private void Awake()
    {
        actorView = GetComponent<ActorView>();
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            if (_enemyFromSpawn) _game.KillEnemy();
            this.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int dmg)
    {
        _currentHealth -= dmg;
        Debug.Log("TakeDamage");
        if(_currentHealth<=0)
        {
            _currentHealth = 0;
            isAlive = false;
            //actorView.PlayDeathAnimation();
        }
    }
}
