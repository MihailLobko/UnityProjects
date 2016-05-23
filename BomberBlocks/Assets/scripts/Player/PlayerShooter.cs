using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] exlosivePrefabs;
    private GameObject _exlosivePrefab;
    private Command _shootCommand;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void Shoot(GameObject exlosivePrefab)
    {
        _exlosivePrefab = Instantiate(exlosivePrefab) as GameObject;
        _shootCommand = new ShootCommand(gameObject, _exlosivePrefab);
        _shootCommand.execute();
    }
}
