using UnityEngine;

public class Teleport : MonoBehaviour               // вешается на Teleport Enemy_1
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _time;
    private float _temp;

    private void Awake()
    {
        _temp = _time;
    }

    private void FixedUpdate()
    {
        _temp -= Time.deltaTime;

        if(_temp<0)
        {
            _temp = _time;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float newX = Random.Range(-15, 15);
            float newZ = Random.Range(-15, 15);
            Vector3 newPosition = new Vector3(_player.transform.position.x + newX, _player.transform.position.y, _player.transform.position.z + newZ);
            _player.transform.position = newPosition;
        }
    }
}
