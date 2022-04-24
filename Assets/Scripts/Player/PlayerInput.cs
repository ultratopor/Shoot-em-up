using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Shooting _shootingPoint;

    // ����� ����� ����������
    [SerializeField] [Range(0,0.5f)] private float _timeToShoot;

    // ����� ����� ������������ ������� ������
    [SerializeField] private float _rechargingTime;

    // �������� ���������� ������� � ��������
    [SerializeField] private int _cartrigesInMagazine;

    // ������������ ���������� ������� � ��������
    [SerializeField] private int _maxCartrigesInMagazine;

    // ������������ ���������� ��������� �������
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
        
        // �����
        if (fire)
        {
            if (switchShooting)
            {
                switchShooting = false;
                StartCoroutine(PlayerShooting());
            }
        }


        // �����������
        if (recharge)
        {
            StartCoroutine(RechargingCartrige());
        }

        // ���������������
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

        // ���������� �������� ������
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

        // ����������� ��������� ��������
        playerMovement.IncreaseSpeed();
        switchShooting = true;
    }
}
