using UnityEngine;

public class FireBulletMovement : MonoBehaviour
{
    [SerializeField] GameObject _fireArea;                                                  // Fire Area
    [Range(0, 1)] public float _speed;                                                      // скорость полёта пули
    private Vector3 _newPosition;                                                           // позиция игрока

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed);

        if (transform.position == _newPosition)
        {
            _fireArea.SetActive(true);
            _fireArea.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }
    }

    public void GetPosition(Vector3 pos)
    {
        _newPosition = pos;
    }
}
