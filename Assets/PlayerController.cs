using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic charater Controller - >https://vionixstudio.com/2022/09/19/unity-character-controller/
public class PlayerController : MonoBehaviour
{
    CharacterController cha;
    public float SpeedMod =1;
    public Vector3 move_speed;
    public float gravity = -9.8f;
    public float jump_speed = 0.5f;

    void Start()
    {
        cha = GetComponent<CharacterController>();
    }

    void Update()
    {
        move_speed = new Vector3(Input.GetAxis("Horizontal"), move_speed.y + gravity * Time.deltaTime, Input.GetAxis("Vertical"));
        move_speed *= SpeedMod;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move_speed.y = jump_speed;
        }
        cha.SimpleMove(move_speed);

        if (cha.isGrounded)
        {
            ///Debug.Log("CharacterController is grounded");
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        //Debug.Log(col.collider.gameObject);
    }



}
