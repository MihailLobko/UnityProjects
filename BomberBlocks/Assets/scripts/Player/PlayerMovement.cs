using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    private CharacterController _characterController;
    private bool isRoad = false;
    private Command _moveForward;
    private Command _moveLeft;
    private Command _moveRight;
    private bool isGround = true;
    public float MoveSpeed = 5.0f;

    void Start ()
    {
        _characterController = GetComponent<CharacterController>();
        _moveForward = new MoveCommand(_characterController, MoveEnum.MOVE_FORWARD, MoveSpeed);
        float horInput = Input.GetAxis("Horizontal");
        _moveLeft = new MoveCommand(_characterController, MoveEnum.MOVE_LEFT,60.55f);
        _moveRight = new MoveCommand(_characterController, MoveEnum.MOVE_RIGHT, 60.55f);
    }
	
	void Update ()
	{
        _moveForward.execute();
        /* if (Input.GetKeyDown("a"))
         {
             MoveLeft();
         }
         if (Input.GetKeyDown("d"))
         {
             MoveRight();
         }
         */
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.8f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Wall" || hitCollider.tag == "DeadZone")
            {
                SceneManager.LoadScene("BomberBlocks");
            }
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Translate(-1,0,0);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(1, 0, 0);
        }

    }

    public void MoveLeft()
    {
        //_moveLeft.execute();
        transform.Translate(-1, 0, 0);
    }

    public void MoveRight()
    {
        //_moveRight.execute();
        transform.Translate(1, 0, 0);
    }



}
