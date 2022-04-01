using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            float newX = Random.Range(-10, 10);
            float newZ = Random.Range(10, 10);
            _player.transform.position = new Vector3(_player.transform.position.x + newX, _player.transform.position.y, _player.transform.position.z + newZ);
        }
    }
}
