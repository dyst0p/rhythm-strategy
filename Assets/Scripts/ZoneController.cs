using System.Collections.Generic;
using UnityEngine;

public class ZoneController: MonoBehaviour
{
    [SerializeField] private float radius = 10;
    private float _sqrRadius;
    
    private static readonly List<IReflectable> AllMovers = new List<IReflectable>();

    private void Awake()
    {
        _sqrRadius = radius * radius;
    }

    public static void AddMover(IReflectable newMover)
    {
        if (!AllMovers.Contains(newMover))
            AllMovers.Add(newMover);
    }

    private void Update()
    {
        foreach (IReflectable mover in AllMovers)
        {
            if (mover.GetPosition().sqrMagnitude >= _sqrRadius)
                CheckCollisionWithBorder(mover);
        }
    }

    private void CheckCollisionWithBorder(IReflectable mover)
    {
        mover.Reflect((Vector2)transform.position - mover.GetPosition());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
