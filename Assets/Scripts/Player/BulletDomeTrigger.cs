using UnityEngine;

public class BulletDomeTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dome"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
