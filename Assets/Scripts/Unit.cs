using UnityEngine;

public class Unit : MonoBehaviour, IReflectable
{
    [SerializeField] private float speed;

    void Awake()
    {
        Register();
    }

    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime), Space.Self);
    }

    public void Reflect(Vector2 normal)
    {
        transform.up = Vector2.Reflect(transform.up, normal.normalized);
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
    
    private void Register()
    {
        ZoneController.AddMover(this);
    }
}
