using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall
{
    private int _wallHealth;
    GameObject[,] _wallParts;

    public Wall(int wallHealth)
    {
        _wallHealth = wallHealth;
    }

    public void DamageWall(int damage)
    {
        _wallHealth-=damage;
    }

    public bool IsLive()
    {
        return _wallHealth > 0;
    }

    public void SetWallParts(GameObject[,] wallParts)
    {
        _wallParts = wallParts;
    }

    public void GetWallHealth()
    {
        foreach (var wallPart in _wallParts)
        {
            if (wallPart.transform.name.Equals("HitSpace(Clone)")) _wallHealth++;
        }    
    }
}
