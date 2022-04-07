using System.Collections.Generic;
using UnityEngine;

public class FireAreaShooting : MonoBehaviour
{
    [SerializeField] private float _fireBallTime;
    [SerializeField] int _maxBalls;               // количество выстрелов перед выключением
    [SerializeField] public GameObject _fireBallObject;
    [SerializeField] public List<GameObject> _roundMagazne;
    public int _count;
    private int _orderFireBallObject = 0;
    private float _temp;
    private int _ballCount;
    

    private void Awake()
    {
        SetTime();

        for (int i = 0; i < _count; i++)
        {
            GameObject bulletObject = Instantiate(_fireBallObject);
            _roundMagazne.Add(bulletObject);
            bulletObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _temp -= Time.deltaTime;

        if (_temp<=0)
        {
            Fire();
            SetTime();
            _ballCount++;
        }

        if (_orderFireBallObject == _count) _orderFireBallObject = 0;
        if (_ballCount >= _maxBalls) 
        { 
            this.gameObject.SetActive(false);
            _ballCount = 0;
        }
    }

    private void SetTime()
    {
        _temp = Random.Range(0, _fireBallTime);
    }

    private void Fire()
    {
        if (!_roundMagazne[_orderFireBallObject].activeSelf)
        {
            _roundMagazne[_orderFireBallObject].SetActive(true);
            _roundMagazne[_orderFireBallObject].transform.position = transform.position;
            _roundMagazne[_orderFireBallObject].GetComponent<FireBallController>().GetPosition();

            _orderFireBallObject++;
        }
    }
}
