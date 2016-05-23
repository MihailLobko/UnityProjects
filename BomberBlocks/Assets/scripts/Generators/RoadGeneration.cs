using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    public GameObject Road;
    public Transform GenerationPoint;
    public float PlatformWidth = 30;
    public ObjectsPooler ObjectsPooler;

    private void Update()
    {
        if (transform.position.z < GenerationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + PlatformWidth);
            GameObject newRoad = ObjectsPooler.GetPooledObject();
            newRoad.transform.position = transform.position;
            newRoad.transform.rotation = transform.rotation;
            newRoad.SetActive(true);
        }
    }
}
