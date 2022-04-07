using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject _bullet;
    [SerializeField] public List<GameObject> _roundMagazne;
    public int _count;
    private int _orderBullet=0;
    

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject bulletObject = Instantiate(_bullet);
            _roundMagazne.Add(bulletObject);
            bulletObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_orderBullet == _count) _orderBullet = 0;
    }

    public void Fire()
    {
        SpawningObjects();

        if (_roundMagazne[_orderBullet].GetComponent<Collider>().CompareTag("Bullet"))
        {
            _roundMagazne[_orderBullet].GetComponent<BulletMovement>().GetNewPosition();
        }

        if (_roundMagazne[_orderBullet].GetComponent<Collider>().CompareTag("EnemyBullet"))
        {
            _roundMagazne[_orderBullet].GetComponent<BulletMovement>().GetPlayerPosition();
        }

        IncreasingOrderBullet();
    }

    public void SpawningObjects()
    {
        if (!_roundMagazne[_orderBullet].activeSelf)
        {
            _roundMagazne[_orderBullet].SetActive(true);
            _roundMagazne[_orderBullet].transform.position = transform.position;
        }
    }

    public void IncreasingOrderBullet()
    {
        _orderBullet++;
    }
}
