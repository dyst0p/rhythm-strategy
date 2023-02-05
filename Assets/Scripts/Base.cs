using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Base : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private float timeToSpawn;

    private void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    private IEnumerator SpawnUnit()
    {
        var timer = new WaitForSeconds(timeToSpawn);
        while (true)
        {
            yield return timer;
            Quaternion rotator = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            Instantiate(unitPrefab, transform.position, unitPrefab.transform.rotation * rotator);
        }
    }
}
