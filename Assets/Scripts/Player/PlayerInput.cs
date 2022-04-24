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

    // максимальное количество собранных зарядов
    [SerializeField] private int _maxCartriges;

    private bool switchShooting=true;
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        #region Moving
        float x = Input.GetAxis(GameData.HORIZONTAL_AXIS);
        float y = Input.GetAxis(GameData.VERTICAL_AXIS);

        playerMovement.Move(x, y);
        #endregion

        #region Fire
        bool fire = Input.GetButton(GameData.FIRE);
        bool recharge = Input.GetButtonDown(GameData.RELOAD);
        
        // огонь
        if (fire)
        {
            if (switchShooting)
            {
                switchShooting = false;
                StartCoroutine(PlayerShooting());
            }
        }


        // перезарядка
        if (recharge)
        {
            StartCoroutine(RechargingCartrige());
        }

        // автоперезарядка
        if(_cartrigesInMagazine==0)
        {
            StartCoroutine(RechargingCartrige());
        }
        #endregion
    }

    IEnumerator PlayerShooting()
    {
        yield return new WaitForSeconds(_timeToShoot);
        _shootingPoint.SpawningObjects();
        switchShooting = true;
    }

    IEnumerator RechargingCartrige()
    {
        switchShooting = false;

        // уменьшение скорости игрока
        playerMovement.DecreaseSpeed();

        while(_cartrigesInMagazine<_maxCartrigesInMagazine)
        {
            yield return new WaitForSeconds(_rechargingTime);
            
            if(_maxCartriges==0)
            {
                break;
            }
            _cartrigesInMagazine++;
            _maxCartriges--;
        }

        // возвращение начальной скорости
        playerMovement.IncreaseSpeed();
        switchShooting = true;
    }
}
