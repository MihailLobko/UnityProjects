using UnityEngine;
using System.Collections;

public class DoubleCubeExplosive : Explosive {

    public int Damage = 1;

    protected override float GetMinDistance()
    {
        return 1.1f;
    }

    protected override void ProcessExplosive()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.56f);
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
