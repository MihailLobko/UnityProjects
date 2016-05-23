using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
    [SerializeField]
    private Transform target;

    // Use this for initialization
    void Start () {

    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
