using UnityEngine;
using System.Collections;

public class MoveCommand : Command
{
    private CharacterController _characterController;
    private MoveEnum _direction;
    private float _moveSpeed;
    private Vector3 _movement = Vector3.zero;
    private float _gravity = -9.8f;

    public MoveCommand(CharacterController characterController, MoveEnum direction, float moveSpeed)
    {
        _characterController = characterController;
        _direction = direction;
        _moveSpeed = moveSpeed;
    }

    public override void execute()
    {       
        switch (_direction)
        {
            case MoveEnum.MOVE_LEFT:
                _movement.x = (float) MoveEnum.MOVE_LEFT*_moveSpeed;
                break;
            case MoveEnum.MOVE_RIGHT:
                _movement.x = (float)MoveEnum.MOVE_RIGHT *_moveSpeed;
                break;
            case MoveEnum.MOVE_FORWARD:
                _movement.z = _moveSpeed;
                break;
        }
        _movement.y = _gravity;
        _movement *= Time.deltaTime;
        _characterController.Move(_movement);
    }

}
