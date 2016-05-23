using UnityEngine;
using System.Collections;
using System.Linq;

public class SmallCubeExplosive : Explosive
{
    public int Damage = 1;

    protected override void ProcessExplosive()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.35f);
        bool isHitSpase = false;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Wall" && _wall == null)
            {
                _wall = hitCollider.transform.gameObject;
            }
            if (hitCollider.tag == "HitSpase")
            {
                isHitSpase = true;                
            }
        }

        if (_wall != null && isHitSpase)
        {
            DamageWall();
        }     
    }

    protected override int GetExplosiveDamage()
    {
        return Damage;
    }
}
