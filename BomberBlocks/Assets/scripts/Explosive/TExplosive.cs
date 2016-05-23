using UnityEngine;
using System.Collections;
using System.Linq;

public class TExplosive : Explosive {
    public int Damage = 1;

    protected override float GetMinDistance()
    {
        return 1.56f;
    }

    protected override void ProcessExplosive()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Wall" && _wall == null)
            {
                _wall = hitCollider.transform.gameObject;
            }
        }


        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "HitSpase")
            {
                DamageWall();
            }
        }

    }

    protected override int GetExplosiveDamage()
    {
        return Damage;
    }
}
