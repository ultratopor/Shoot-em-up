using UnityEngine;

public class ActivateTeleport : MonoBehaviour                   // вешается на Enemy Enemy_1. Активирует телепорт
{
    [SerializeField] private Transform _player;                 // игрк
    [SerializeField] private GameObject _teleport;              // телепорт
    [SerializeField] private float _offset;                     // смещение конечной точки

    public void OpenTeleport()
    {
        _teleport.SetActive(true);
        _teleport.transform.position = new Vector3(_player.position.x + _offset, _player.position.y, _player.position.z + _offset);
    }
}
