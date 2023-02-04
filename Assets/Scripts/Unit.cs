using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime), Space.Self);
    }
}
