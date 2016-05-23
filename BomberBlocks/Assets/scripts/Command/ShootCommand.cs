using UnityEngine;

public class ShootCommand : Command
{
    private readonly GameObject _explosive;
    private readonly GameObject _actor;

    public ShootCommand(GameObject actor, GameObject explosive)
    {
        _actor = actor;
        _explosive = explosive;
    }

    public override void execute()
    {
        _explosive.transform.position = _actor.transform.TransformPoint(Vector3.forward*1.5f);
        _explosive.transform.rotation = _actor.transform.rotation;
    }
}
