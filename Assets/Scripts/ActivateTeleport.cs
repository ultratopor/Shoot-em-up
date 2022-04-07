using UnityEngine;

public class ActivateTeleport : MonoBehaviour                   // вешается на Enemy Enemy_1. Активирует телепорт
{
    [SerializeField] private Transform _player;                 // игрк
    [SerializeField] private GameObject _teleport;              // телепорт
    [SerializeField] [Range(1, 5)] private int _minDistanse;    // минимальная дистанция до игрока для активации телепорта
    [SerializeField] [Range(5, 15)] private int _maxDistanse;   // максимальная дистанция до игрока для активации телепорта
    [SerializeField] private float _timeOpen;                   // время между активациями телепорта
    [SerializeField] private float _offset;                     // смещение конечной точки
    private float _temp;                                        // внутреннее поле для отсчёта времени

    private void Awake()
    {
        _temp = _timeOpen;
    }

    private void FixedUpdate()
    {
        Vector3 heading = _player.position - transform.position;
        float distance = heading.magnitude;

        _temp -= Time.deltaTime;

        if (distance<_maxDistanse&&distance>_minDistanse)
        {
            if(_temp<0)
            {
                _teleport.SetActive(true);
                _temp = _timeOpen;
                _teleport.transform.position = new Vector3(_player.position.x + _offset, _player.position.y, _player.position.z + _offset);
            }
        }
    }
}
