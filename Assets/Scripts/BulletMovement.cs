using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [Range(0, 1)] public float _speed;
    private Vector3 _newPosition;
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed);

        if (transform.position == _newPosition)
        { 
            this.gameObject.SetActive(false); 
        }
    }

    public void GetNewPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            _newPosition = hit.point;
        }
    }

    public void GetPlayerPosition()
    {
        _newPosition = _player.position;
    }
}
