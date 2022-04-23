using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDomeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dome")) this.gameObject.SetActive(false);
        Debug.Log("Dome");
    }
}
