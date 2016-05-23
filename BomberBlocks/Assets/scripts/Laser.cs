using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    private GameObject _aim;

    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start ()
	{
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
	    if (Physics.Raycast(transform.position, transform.forward, out hit, 100, ~(1<<8)))
	    {
                lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
	            if (_aim == null)
	            {
                        _aim = Instantiate(aim) as GameObject;
                        _aim.transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z - 1 );
                        _aim.transform.parent = transform;
              
                }
	            if (transform.hasChanged)
	            {
                    _aim.transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z - 1);
                    _aim.transform.parent = transform;
                }         
	    }
	    else
	    {
	        lineRenderer.SetPosition(1, new Vector3(0,0,5000));
	    }       
    }
}
