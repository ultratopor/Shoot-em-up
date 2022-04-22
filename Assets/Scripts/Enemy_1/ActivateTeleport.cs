using UnityEngine;

public class ActivateTeleport : MonoBehaviour                   // �������� �� Enemy Enemy_1. ���������� ��������
{
    [SerializeField] private Transform _player;                 // ����
    [SerializeField] private GameObject _teleport;              // ��������
    [SerializeField] private float _offset;                     // �������� �������� �����

    public void OpenTeleport()
    {
        _teleport.SetActive(true);
        _teleport.transform.position = new Vector3(_player.position.x + _offset, _player.position.y, _player.position.z + _offset);
    }
}
