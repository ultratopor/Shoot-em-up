using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _teleport;
    [SerializeField] [Range(1, 5)] private int _minDistanse;
    [SerializeField] [Range(5, 15)] private int _maxDistanse;
    [SerializeField] private float _timeOpen;
    private float _temp;

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
                _teleport.transform.position = new Vector3(_player.position.x + 0.5f, _player.position.y, _player.position.z + 0.5f);
            }
        }
    }
}
