using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour               // вешается на Teleport Enemy_1
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _timeToDisactivate;

    private void OnEnable()
    {
        StartCoroutine(Disactivate());
    }
    IEnumerator Disactivate()
    {
        yield return new WaitForSeconds(_timeToDisactivate);
        this.gameObject.SetActive(false);
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
