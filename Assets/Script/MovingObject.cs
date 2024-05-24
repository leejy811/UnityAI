using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;

public enum MoveState { Back, Default, Down, Forward, Left, Right, Up };

public class MovingObject : MonoBehaviour
{
    public Dictionary<MoveState, Vector3> moveDirection = new Dictionary<MoveState, Vector3>();
    public float speed;

    [SerializeField] MoveState moveState;
    Rigidbody rigid;

    private void Start()
    {
        moveDirection[MoveState.Default] = Vector3.zero;

        moveDirection[MoveState.Up] = Vector3.up;
        moveDirection[MoveState.Down] = Vector3.down;

        moveDirection[MoveState.Forward] = Vector3.right;
        moveDirection[MoveState.Back] = Vector3.left;

        moveDirection[MoveState.Right] = Vector3.back;
        moveDirection[MoveState.Left] = Vector3.forward;

        rigid = gameObject.GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        moveState = MoveState.Forward;
    //    }
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        moveState = MoveState.Back;
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        moveState = MoveState.Left;
    //    }
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        moveState = MoveState.Right;
    //    }
    //    else if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        moveState = MoveState.Up;
    //    }
    //    else if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        moveState = MoveState.Down;
    //    }
    //    else
    //    {
    //        moveState = MoveState.Default;
    //    }
    //}

    private void FixedUpdate()
    {
        rigid.velocity = moveDirection[moveState] * speed;
        //transform.position += moveDirection[moveState] * speed * Time.fixedDeltaTime;
    }

    public void ChangeMove(MoveState state)
    {
        moveState = state;
    }
}
