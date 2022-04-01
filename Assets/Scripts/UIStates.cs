using UnityEngine;

public class UIStates : MonoBehaviour
{
    [SerializeField] GameObject firstState;
    private GameObject _currentState;
    private void Awake()
    {
        ChangeState(firstState);
    }

    public void ChangeState(GameObject newState)
    {
        if (_currentState!=null)
        {
            _currentState.SetActive(false);
        }

        _currentState = newState;

        if (_currentState!=null)
        {
            _currentState.SetActive(true);
        }
    }
}
