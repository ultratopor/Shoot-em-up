using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Range(0, 1)] public float _speed;
    private Vector3 _newPosition;
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed);

        if (transform.position == _newPosition) this.gameObject.SetActive(false);
    }

    public void GetNewPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            _newPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    public void GetPlayerPosition()
    {
        _newPosition = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }
}
