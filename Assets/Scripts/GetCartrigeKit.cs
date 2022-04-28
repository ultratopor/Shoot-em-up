using UnityEngine;

public class GetCartrigeKit : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.TakeCartrigeKit();
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
