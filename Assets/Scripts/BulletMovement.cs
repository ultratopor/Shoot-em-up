using UnityEngine;

public class BulletMovement : MonoBehaviour                                             // �������� �� Bullet � EnemyBullet
{
    [Range(0, 1)] public float _speed;
    private Vector3 newPosition;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _isFireBullet;
    [SerializeField] private FireBulletController _enemyShootingPoint;

    private void OnEnable()
    {
        if (this.GetComponent<Collider>().CompareTag("Bullet")) GetNewPosition();

        if (this.GetComponent<Collider>().CompareTag("EnemyBullet")) GetPlayerPosition();

    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed);

        if (transform.position == newPosition)
        {
            if (_isFireBullet) _enemyShootingPoint.ActivateFireArea();
            this.gameObject.SetActive(false); 
        }
    }

    private void GetNewPosition()  // ������� ������
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            newPosition = hit.point;
        }
    }

    private void GetPlayerPosition()  // ������� �����
    {
        newPosition = _player.position;
    }
}
