using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wallCube;
    [SerializeField] private GameObject hitSpace;

    private GameObject _wall;
    private GameObject _player;
    private GameObject[,] wallParts;
    private WallController controller;

    private int hitSpaceCount;
    private int Count;
    private bool includeHit = false;

    public int RowCount;
    public int ColumnCount;
    public int maxCount;
    public float speedMultiplier;
    public float speedIncreaseMilestone;

    private float speedMilestoneCount;

    void Start ()
    {
        _player = GameObject.Find("Player");
        hitSpaceCount = 1;
        maxCount = 4;
        GenerateWall();
        speedMilestoneCount = speedIncreaseMilestone;
    }

    private void GenerateWall()
    {
        if (_player.transform.position.z > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = (float) (speedIncreaseMilestone* 1.5);
            if (hitSpaceCount < maxCount)
            {
                hitSpaceCount++;
            }
            if (hitSpaceCount % 4 == 0)
            {
                maxCount += 4;
                RowCount++;
            }
            Debug.Log("hitSpaceCount= " + hitSpaceCount);
            Debug.Log("RowCount= " + RowCount);
        }

        Count = hitSpaceCount;

        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        wallParts = new GameObject[(int)RowCount, (int)ColumnCount];
        _wall = GenerateWallUnit(new Vector3(transform.position.x, transform.position.y, transform.position.z), wall);
        _wall.transform.parent = transform.parent;
        BoxCollider wallCollider = _wall.GetComponent<BoxCollider>();
        wallCollider.size = new Vector3(ColumnCount, 1, RowCount);
        controller = _wall.GetComponent<WallController>();

        BoxCollider wallCubeCollider = wallCube.GetComponent<BoxCollider>();

        Vector3 transformCube = new Vector3(transform.position.x - (wallCollider.size.x / 2 - wallCubeCollider.size.x / 2), transform.position.y, transform.position.z + (wallCollider.size.z / 2 - wallCubeCollider.size.z / 2));
        GameObject firstCube = GenerateWallUnit(transformCube, wallCube);

        firstCube.transform.parent = _wall.transform;
        wallParts[0, 0] = firstCube;

        float offset = firstCube.GetComponent<BoxCollider>().size.x;

        for (int i = 1; i < ColumnCount; i++)
        {
            GameObject cube = GenerateWallUnit(new Vector3(wallParts[0, i - 1].transform.position.x + offset, transform.position.y, firstCube.transform.position.z), wallCube);
            cube.transform.parent = _wall.transform;
            wallParts[0, i] = cube;
        }

        for (int i = 1; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                GameObject previousCube = wallParts[i - 1, j];
                GameObject cube = GenerateWallUnit(new Vector3(previousCube.transform.position.x, transform.position.y, previousCube.transform.position.z - offset), GetBlockOrHit(previousCube));
                wallParts[i, j] = cube;
                cube.transform.parent = _wall.transform;
            }
        }

        if (!includeHit)
        {
            wallParts[RowCount - 1, ColumnCount - 1] = GenerateWallUnit(new Vector3(wallParts[RowCount - 2, ColumnCount - 1].transform.position.x, transform.position.y, wallParts[RowCount - 2, ColumnCount - 1].transform.position.z - offset), getHitSpace());
        }

        transform.position = startPosition;
    }

    private GameObject GetBlockOrHit(GameObject previousCube)
    {
        int index = Random.Range(0, 3);
        Debug.Log("index= " + index);
        if ((index > 0 && !previousCube.transform.name.Equals("HitSpace(Clone)")))
        {
            return wallCube;
        }
        if (Count > 0)
        {
            return getHitSpace();
        }
        if (previousCube.transform.name.Equals("HitSpace(Clone)"))
        {
            controller.WallHealth++;
            return hitSpace;
        }
        return wallCube;
    }

    private GameObject getHitSpace()
    {
        controller.WallHealth++;
        Count--;
        includeHit = true;
        return hitSpace;
    }

    private GameObject GenerateWallUnit(Vector3 position, GameObject _gameObject)
    {
        transform.position = position;
        GameObject generetedObject = (GameObject)Instantiate(_gameObject);
        generetedObject.transform.position = transform.position;
        generetedObject.transform.rotation = transform.rotation;
        return generetedObject;
    }

    void Update () {
        if (transform.position.z + 20 < _player.transform.position.z)
        {
            if (!controller.IsLive() && _wall == null)
            {
                GenerateWall();
            }
        }
    }

}
