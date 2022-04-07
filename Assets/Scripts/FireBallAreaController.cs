using UnityEngine;

public class FireBallAreaController : MonoBehaviour
{
    [SerializeField] private float _activeTime;
    private float _temp;

    private void Awake()
    {
        _temp = _activeTime;
    }

    private void FixedUpdate()
    {
        _temp -= Time.deltaTime;

        if (_temp <= 0) 
        { 
            this.gameObject.SetActive(false);
            _temp = _activeTime;
        }
    }
}
