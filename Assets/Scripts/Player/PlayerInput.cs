using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Shooting _shootingPoint;

    // время между выстрелами
    [SerializeField] [Range(0,0.5f)] private float _timeToShoot;

    // время между перезарядкой каждого заряда
    [SerializeField] private float _rechargingTime;

    // реальное количество зарядов в магазине
    [SerializeField] private int _cartrigesInMagazine;

    // максимальное количество зарядов в магазине
    [SerializeField] private int _maxCartrigesInMagazine;

    // количество собранных зарядов
    [SerializeField] private int _currentCartriges;

    // максимальное количество собранных зарядов
    [SerializeField] private int _maxCartriges;

    // количество зарядов в коробке 
    [SerializeField] private int _cartrigeInKit;

    private bool switchShooting=true;

    private bool rechargeIsOn=true;
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        #region Moving
        float x = Input.GetAxis(GameData.HORIZONTAL_AXIS);
        float y = Input.GetAxis(GameData.VERTICAL_AXIS);

        playerMovement.Move(x, y);
        #endregion

        #region Fire
        bool fire = Input.GetButton(GameData.FIRE);
        bool recharge = Input.GetButton(GameData.RELOAD);
        
        // огонь
        if (fire)
        {
            if (_cartrigesInMagazine > 0)
            {
                if (switchShooting)
                {
                    switchShooting = false;
                    StartCoroutine(PlayerShooting());
                }
            }
        }

        // перезарядка
        if (recharge)
        {
            if (_currentCartriges > 0)
            {
                if (rechargeIsOn)
                {
                    rechargeIsOn = false;
                    switchShooting = false;
                    StartCoroutine(RechargingCartrige());
                }
            }
        }

        // автоперезарядка
        if(_cartrigesInMagazine <= 0)
        {
            if (_currentCartriges > 0)
            {
                if (rechargeIsOn)
                {
                    rechargeIsOn = false;
                    switchShooting = false;
                    StartCoroutine(RechargingCartrige());
                }
            }
        }
        #endregion
    }

    IEnumerator PlayerShooting()
    {
        yield return new WaitForSeconds(_timeToShoot);
        _shootingPoint.SpawningObjects();
        _cartrigesInMagazine--;
        switchShooting = true;
    }

    IEnumerator RechargingCartrige()
    {
        

        // уменьшение скорости игрока
        playerMovement.DecreaseSpeed();

        for (int i = _cartrigesInMagazine; i < _maxCartrigesInMagazine; i++)
        {
            yield return new WaitForSeconds(_rechargingTime);

            if (_currentCartriges <= 0)
            {
                break;
            }

            _cartrigesInMagazine++;
            _currentCartriges--;

        }

        // возвращение начальной скорости
        playerMovement.IncreaseSpeed();
        switchShooting = true;
        rechargeIsOn = true;
    }

    // взаимодействие с коробков зарядов
    public void TakeCartrigeKit()
    {
        _currentCartriges += _cartrigeInKit;
        if (_currentCartriges > _maxCartriges) _currentCartriges = _maxCartriges;
    }
}
