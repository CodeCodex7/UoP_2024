using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//This script is hella messy
//Basic charater Controller - >https://vionixstudio.com/2022/09/19/unity-character-controller/
public class PlayerController : MonoBehaviour
{
    public CharacterController cha;
    public float SpeedMod =1;
    public float Jump_Mod = 0.5f;
    public Vector3 move_speed;
    public float gravity = -9.8f;
    public float jump_speed = 0.5f;
    public GameObject PlayerAvatar;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;

    public bool LockoutMovment = false;

    public Animator AnimController;

    public GameObject OverHead_Notification;

    void Start()
    {
        cha = GetComponent<CharacterController>();
        Services.Resolve<GameManager>().ActivePlayer = this.gameObject;
        Services.Resolve<GlobalMessanger>().Subscribe(6, OnInventory);
    }

    void Update()
    {

        Menus();
        if (!LockoutMovment)
        {
            groundedPlayer = cha.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
                Jump_Mod = 1;
                AnimController.SetBool("Jump", false);
            }
            else
            {
                Jump_Mod = 0.75f;
            }

            var cam = Camera.main;
            //move_speed = new Vector3(Input.GetAxis("Horizontal"), move_speed.y + gravity * Time.deltaTime, Input.GetAxis("Vertical"));

            ////move_speed = move_speed + Camera.main.transform.forward;
            //move_speed *= SpeedMod;

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), move_speed.y + gravity, Input.GetAxis("Vertical"));

            movement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * movement;
            movement *= SpeedMod * Jump_Mod;

            var MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            MovementDirection = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * MovementDirection;

            MovementDirection.Normalize();

            if (MovementDirection != Vector3.zero)
            {
                PlayerAvatar.transform.forward = MovementDirection;
            }


            AnimController.SetFloat("Speed", cha.velocity.magnitude);

            //move_speed = Vector3.Cross(move_speed, Camera.main.transform.eulerAngles);
            if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                Debug.Log("jump");
                AnimController.SetBool("Jump", true);
            }
            playerVelocity.y += gravity * Time.deltaTime;
            movement.y = playerVelocity.y;

            cha.Move(movement * Time.deltaTime);
        }
        
        //cha.Move(playerVelocity * Time.deltaTime);

    }

    void Menus()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            var canvasC = Services.Resolve<CanvasController>();

            if (!canvasC.ActiveCanvasCheck("Inventory"))
            {
                Services.Resolve<InventoryUI>().OpenInventory(0);
                LockoutMovment = true;
               
            }
            else
            {
                Services.Resolve<InventoryUI>().CloseInventory();
            }
        }
    }

    public void ShowNotfication(bool State)
    {
        OverHead_Notification.SetActive(State);
    }
    void OnInventory(MessageData Data)
    {
        var inv = Data.ObjData as InventoryUI.InventoryMeesageData; 
        if (inv.Open == 0)
        {
            LockoutMovment = false;
            Debug.Log("Trigger");
        }
        else
        {

        }

       
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        //Debug.Log(col.collider.gameObject);
    }



}
