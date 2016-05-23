using UnityEngine;
using System.Collections;

public class RoadPoller : ObjectsPooler
{
    public GameObject PoolRoadPoller;

    public override GameObject GetPoolGameObject()
    {
        return PoolRoadPoller;
    }

}
