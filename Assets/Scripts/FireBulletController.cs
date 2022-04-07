using UnityEngine;

public class FireBulletController : MonoBehaviour                       // �������� �� EnemyShootingPoint Enemy Enemy_2
{
    /// <summary>
    /// �����
    /// </summary>
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _fireBullet;                    // FireBullet
    [SerializeField] private EnemyMovement _enemy;                      // Enemy Enemy_2
    [SerializeField] [Range(1, 5)] private int _minDistanse;            // ����������� ��������� �� ������
    [SerializeField] [Range(5, 15)] private int _maxDistanse;           // ������������ ��������� �� ������
    /// <summary>
    /// ����� ����� ����������
    /// </summary>
    [SerializeField] private float _timeToShoot;
    /// <summary>
    /// ����� ��������� ����� ����� ���������
    /// </summary>
    [SerializeField] private float _timeToStop;
    private float _temp_shoot;
    private float _temp_stop;

    private void Start()
    {
        _temp_shoot = _timeToShoot;
        _temp_stop = _timeToStop;
    }

    private void FixedUpdate()
    {
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;

        _temp_shoot -= Time.deltaTime;
        if (distance < _maxDistanse && distance > _minDistanse)           // ������� ��������� �� ������
        {
            if (_temp_shoot <= 0)                                         // ������� ������� ��������� ����� ����� ��������� 
            {
                _enemy.Stoping();
                _temp_stop -= Time.deltaTime;

                if (_temp_stop <= 0)                                       // ������� �������� ����� ���������
                {
                    _fireBullet.SetActive(true);
                    _fireBullet.transform.position = transform.position;
                    _fireBullet.GetComponent<FireBulletMovement>().GetPosition(_player.position);
                    _temp_shoot = _timeToShoot;
                    _temp_stop = _timeToStop;
                    _enemy.Starting();
                }
            }
        }
    }
}
