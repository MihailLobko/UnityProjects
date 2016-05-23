using System.Linq;
using UnityEngine;

public abstract class Explosive : MonoBehaviour
{
    public float Speed = 10.0f;
    public const float MinDistance = 0.7f;

    protected RaycastHit LeftHit;
    protected RaycastHit RightHit;

    protected abstract void ProcessExplosive();
    protected abstract int GetExplosiveDamage();

    protected virtual float GetMinDistance()
    {
        return 0.6f;
    }

    protected GameObject _wall;

    private void Update()
    {
        transform.Translate(transform.TransformDirection(transform.forward*Speed*Time.deltaTime));
        RaycastHit raycastHit;
        if (Speed > 0.0f &&
            Physics.Raycast(transform.position, Vector3.forward, out raycastHit, 500, ~((1 << 8) | (1 << 13))))
        {
            if (raycastHit.distance <= GetMinDistance() &&
                (raycastHit.collider.tag == "WallCube" || raycastHit.collider.tag == "Explosive"))
            {
                Speed = 0.0f;
                ProcessExplosive();
            }
        }
    }

    protected bool IsHitTarget(Vector3 position, Vector3 direction, out RaycastHit raycastHit)
    {
        if (Physics.Raycast(position, direction, out raycastHit))
        {
            return raycastHit.distance <= MinDistance;
        }
        return false;
    }

    protected void DamageWall()
    {
        var wallController = _wall.GetComponent<WallController>();
        wallController.DamageWall(GetExplosiveDamage());
        if (!wallController.IsLive())
        {
            GameObject.FindGameObjectsWithTag("Explosive").ToList().ForEach(x => Destroy(x));
        }
    }
}
