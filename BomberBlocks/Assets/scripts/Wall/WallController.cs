using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    public int WallHealth;
    private Wall _wall;

    void Start () {
        _wall = new Wall(WallHealth);
        Debug.Log(_wall);
    }

    public void DamageWall(int damage)
    {
       _wall.DamageWall(damage);
        if (!_wall.IsLive())
        {
            Messenger.Broadcast(GameEvent.ENEMY_HIT);
            Destroy(gameObject);
        }        
    }

    public void SetWallParts(GameObject[,] wallParts)
    {
        _wall.SetWallParts(wallParts);
    }

    public bool IsLive()
    {
        return _wall.IsLive();
    }
}
