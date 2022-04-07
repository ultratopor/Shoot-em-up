using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireBallController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _force;
    [SerializeField] private float _activeTime;
    [SerializeField] private GameObject _fireBallArea;
    private Vector3 _direction;
    private float _temp;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) 
        {
            _fireBallArea.SetActive(true);
            _fireBallArea.transform.position = transform.position;
        }
    }

    public void GetPosition()
    {
        _direction= new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f));
        rb.AddForce(_direction*_force, ForceMode.Impulse);
    }
}
