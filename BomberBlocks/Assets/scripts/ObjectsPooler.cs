using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectsPooler : MonoBehaviour
{

    public int pooledAmount;

    List<GameObject> pooledObjects; 

	// Use this for initialization
	void Start () {
	    pooledObjects = new List<GameObject>();

	    for (int i=0; i< pooledAmount; i++)
	    {
	        GameObject obj = (GameObject)Instantiate(GetPoolGameObject());
            obj.SetActive(false);
	        pooledObjects.Add(obj);       
	    }
	}

    public GameObject GetPooledObject()
    {
        foreach (GameObject gameObject in pooledObjects)
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }    
        }
        GameObject obj = (GameObject)Instantiate(GetPoolGameObject());
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

    public abstract GameObject GetPoolGameObject();
}
