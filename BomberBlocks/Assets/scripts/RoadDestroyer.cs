using UnityEngine;
using System.Collections;

public class RoadDestroyer : MonoBehaviour
{

    public GameObject RoadDestructionPoint;

	// Use this for initialization
	void Start ()
	{
        RoadDestructionPoint = GameObject.Find("RoadDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.z < RoadDestructionPoint.transform.position.z)
	    {
            gameObject.SetActive(false);
        }
	}
}
