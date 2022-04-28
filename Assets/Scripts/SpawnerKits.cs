using UnityEngine;

public class SpawnerKits : MonoBehaviour
{
    [SerializeField] private GameObject _aidKit;
    [SerializeField] private GameObject _cartrigeKit;
    private GameObject spawnObject;

    public void SpawnKit()
    {
        int temp = Random.Range(0, 10);

        if(temp == 1)
        {
            spawnObject = Instantiate(_aidKit);
            SetAtributes();
        }

        if(temp == 2 || temp == 3)
        {
            spawnObject = Instantiate(_cartrigeKit);
            SetAtributes();
        }
    }

    private void SetAtributes()
    {
        spawnObject.SetActive(true);
        spawnObject.transform.position = transform.position;
    }
}
