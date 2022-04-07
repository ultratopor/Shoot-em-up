using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(1,55)] public int _currentHealth;
    private bool _isAlive=true;

    private ActorView _actorView;

    private void Awake()
    {
        _actorView = GetComponent<ActorView>();
    }

    private void FixedUpdate()
    {
        if (!_isAlive)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int dmg)
    {
        _currentHealth -= dmg;
        Debug.Log("TakeDamage");
        if(_currentHealth<=0)
        {
            _currentHealth = 0;
            _isAlive = false;
            //actorView.PlayDeathAnimation();
        }
    }
}
