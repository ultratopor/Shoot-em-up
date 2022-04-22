using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FireBallController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _force;
    [SerializeField] private float _activeTime;
    [SerializeField] private GameObject _fireBallArea;
    private Vector3 direction;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GetPosition();
        StartCoroutine(DisactivateFireBall());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) 
        {
            _fireBallArea.SetActive(true);
            _fireBallArea.transform.position = transform.position;
        }
    }

    private void GetPosition()
    {
        direction= new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
        rb.AddForce(direction*_force, ForceMode.Impulse);
    }

    IEnumerator DisactivateFireBall()
    {
        yield return new WaitForSeconds(_activeTime);
        this.gameObject.SetActive(false);
    }
}
