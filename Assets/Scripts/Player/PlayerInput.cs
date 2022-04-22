using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public Shooting _shooting;
    [SerializeField] [Range(0,0.5f)] private float _timeToShoot;
    private bool _switchShooting=true;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
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
        
        if (fire)
        {
            if (_switchShooting)
            {
                _switchShooting = false;
                StartCoroutine(PlayerShooting());
            }
        }
        #endregion
    }

    IEnumerator PlayerShooting()
    {
        yield return new WaitForSeconds(_timeToShoot);
        _shooting.SpawningObjects();
        _switchShooting = true;
    }
}
