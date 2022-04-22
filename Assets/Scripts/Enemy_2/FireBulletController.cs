using UnityEngine;

public class FireBulletController : MonoBehaviour                       // вешается на EnemyShootingPoint Enemy Enemy_2
{
    [SerializeField] private GameObject _fireBullet;
    [SerializeField] private GameObject _fireArea;

    public void ShootFireBullet()
    {
        _fireBullet.SetActive(true);
        _fireBullet.transform.position = transform.position;
    }

    public void ActivateFireArea()
    {
        _fireArea.SetActive(true);
        _fireArea.transform.position = _fireBullet.transform.position;
    }
}
