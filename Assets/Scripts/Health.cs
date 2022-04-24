using UnityEngine;

public class Health : MonoBehaviour
{
    // ��������
    [SerializeField] [Range(1,4)] private int _currentHealth;

    // �������� � Enemy_1, Enemy_2, Enemy_3
    [SerializeField] private bool _enemyFromSpawn;

    // �������� � Enemy_1, Enemy_2, Enemy_3
    [SerializeField] private Spawner _game;

    // ������������ ������
    [SerializeField] private GameObject _parentObject;

    private bool isAlive=true;

    //
    [Range(0,4)] private int health;

    private ActorView actorView;

    private void Awake()
    {
        actorView = GetComponent<ActorView>();
    }

    private void OnEnable()
    {
        health = _currentHealth;
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            if (_enemyFromSpawn) _game.KillEnemy();
            _parentObject.SetActive(false);
            transform.position = _parentObject.transform.position;
            isAlive = true;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("TakeDamage");
        if(health<=0)
        {
            health = 0;
            isAlive = false;
            //actorView.PlayDeathAnimation();
        }
    }

    public void TakeAidKit()
    {
        health++;
        if (health > _currentHealth) health = _currentHealth;
    }
}
