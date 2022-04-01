using UnityEngine;

public class FireBulletController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _fireBullet;
    [SerializeField] [Range(1, 5)] private int _minDistanse;
    [SerializeField] [Range(5, 15)] private int _maxDistanse;
    [SerializeField] private float _timeToShoot;
    private float _temp;

    private void Awake()
    {
        _temp = _timeToShoot;
    }

    private void FixedUpdate()
    {
        _temp -= Time.deltaTime;

        if (_temp<0)
        {
            _fireBullet.SetActive(true);
            _fireBullet.transform.position = transform.position;
            _temp = _timeToShoot;
        }
    }
}
