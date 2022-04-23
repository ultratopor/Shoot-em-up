using System.Collections;
using UnityEngine;

public class ExplosionAreaController : MonoBehaviour
{
    [SerializeField] private GameObject _enemy_4;
    [SerializeField] private float _activeTime;

    private void OnEnable()
    {
        StartCoroutine(Deactivation());
    }

    IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(_activeTime);
        this.gameObject.SetActive(false);
        _enemy_4.SetActive(false);
    }
}
