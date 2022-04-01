using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public Shooting _shooting;
    [SerializeField] [Range(0,0.5f)] private float _timeToShoot;
    private float _temp;
    private bool _switchShooting=true;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _temp=_timeToShoot;
    }

    private void FixedUpdate()
    {
        #region Moving
        float x = Input.GetAxis(GameData.HORIZONTAL_AXIS);
        float y = Input.GetAxis(GameData.VERTICAL_AXIS);

        _playerMovement.Move(x, y);
        #endregion

        #region Fire
        bool fire = Input.GetButton(GameData.FIRE);

        if (!_switchShooting)
        {
            _temp -= Time.deltaTime;
            if(_temp < 0)
            {
                _switchShooting = true;
                _temp = _timeToShoot;
            }
        }

        if (fire)
        {
            if (_switchShooting)
            {
                _shooting.Fire();
                _switchShooting = false;
            }
        }
        #endregion
    }
}
