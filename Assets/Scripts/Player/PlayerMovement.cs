using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rechargeSpeed;

    public void Move(float x,float y)
    {
        Vector3 newPosition = new Vector3(transform.position.x + x * _speed, 0, transform.position.z + y * _speed);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }

    public void DecreaseSpeed()
    {
        _speed -= _rechargeSpeed;
    }

    public void IncreaseSpeed()
    {
        _speed += _rechargeSpeed;
    }
}
