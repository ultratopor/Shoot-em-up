using UnityEngine;

public class FireBulletController : MonoBehaviour                       // вешается на EnemyShootingPoint Enemy Enemy_2
{
    /// <summary>
    /// игрок
    /// </summary>
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _fireBullet;                    // FireBullet
    [SerializeField] private EnemyMovement _enemy;                      // Enemy Enemy_2
    [SerializeField] [Range(1, 5)] private int _minDistanse;            // минимальная дистанция до игрока
    [SerializeField] [Range(5, 15)] private int _maxDistanse;           // максимальная дистанция до игрока
    /// <summary>
    /// время между выстрелами
    /// </summary>
    [SerializeField] private float _timeToShoot;
    /// <summary>
    /// время остановки врага перед выстрелом
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
        if (distance < _maxDistanse && distance > _minDistanse)           // условие дистанции до игрока
        {
            if (_temp_shoot <= 0)                                         // условие времени остановки врага перед выстрелом 
            {
                _enemy.Stoping();
                _temp_stop -= Time.deltaTime;

                if (_temp_stop <= 0)                                       // условие выстрела после остановки
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
