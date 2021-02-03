using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private CharacterController charController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float moveSpeed = 5f;
    private bool canMove;
    private bool finished_Movement = true;

    private float player_ToPointDistance;
    private Vector3 target_Pos = Vector3.zero;
    private Vector3 Player_Move = Vector3.zero;

    private float gravity = 9.8f;
    private float height;
    AudioSource audioSrc;

   

    void Awake()
    {
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        CalculateHeight();
        CheckIfFinishedMovement();
        
    }


    bool IsGrounded()
    {
        return collisionFlags == CollisionFlags.CollidedBelow ? true : false;
    }

    void CalculateHeight()
    {
        if (IsGrounded())
        {
            height = 0f;
        }
        else
        {
            height -= gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement()
    {
        if (!finished_Movement)
        {
            if(!anim.IsInTransition(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Stand")
                && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                //Normalized time of the animation is represented from 0 to 1
                finished_Movement = true;
            }
        }
        else
        {
            MoveThePlayer();
            Player_Move.y = height * Time.deltaTime;
            collisionFlags = charController.Move(Player_Move);
        }
    }

    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            // Makes UI Block Raycast So you dont walk when pressing on UI
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            //Calculates where the mouse is clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {

                //If the target hit is of type terrain player will move to that position
                if (hit.collider is TerrainCollider || hit.collider is BoxCollider)
                {
                    player_ToPointDistance = Vector3.Distance(transform.position, hit.point);

                    if (player_ToPointDistance >= .3f)
                    {
                        audioSrc.Play();
                        canMove = true;
                        target_Pos = hit.point;
                    }
                }
            }

        }
        if (canMove)
        {
            //triggers the walk animation to a speed of 1 which will trigger run animation
            anim.SetFloat("Walk", 1.0f);
            


            Vector3 target_Temp = new Vector3(target_Pos.x, transform.position.y, target_Pos.z);

            //Rotates the player towards the target poisition in order to move there
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(target_Temp - transform.position),
                15f * Time.deltaTime);
            

            Player_Move = transform.forward * moveSpeed * Time.deltaTime;
            

            if (Vector3.Distance(transform.position, target_Pos) <= 1f)
            {
                canMove = false;
                audioSrc.Stop();
            }

        }
        else
        {
            Player_Move.Set(0f, 0f, 0f);
            anim.SetFloat("Walk", 0f);
        }
    }

    public bool FinishedMovemet
    {
        get 
        { 
            return finished_Movement; 
        }
        set 
        { 
            finished_Movement = value; 
        }
    }

    public Vector3 TargetPosition
    {
        get
        {
            return target_Pos;
        }
        set
        {
            target_Pos = value;
        }
    }
}
