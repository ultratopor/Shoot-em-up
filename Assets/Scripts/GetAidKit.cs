using UnityEngine;

public class GetAidKit : MonoBehaviour
{
    [SerializeField] private Health _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.TakeAidKit();
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
