using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  
    private Animator animator;
    private CharacterController characterController;

    [SerializeField] private float walkSpeed    = 2.0f;
    [SerializeField] private float runSpeed     = 5.0f;
    [SerializeField] private float turnSpeed    = 100.0f;
    [SerializeField] private float jumpPower    = 5f;


    private int MoveXHash = Animator.StringToHash("MOVEX");
    private int MoveYHash = Animator.StringToHash("MOVEY");
    private int JumpHash = Animator.StringToHash("JUMP");
    private int GroundedHash = Animator.StringToHash("GROUNDED");
    private int FlipHash = Animator.StringToHash("FLIP");


    [SerializeField] Vector3 gravity = Vector3.zero;


    private bool abilityDoubleJump;
    public bool AbilityDoubleJump { get => abilityDoubleJump; set { abilityDoubleJump = value; Debug.Log("got") ; } }

    private void Awake()
    {
        // Chache components
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        CheckGroundLevel();

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        bool runKey = Input.GetKey(KeyCode.LeftShift);


    
        // Run fast
        float speed = (runKey) ? runSpeed : walkSpeed;

       

       
        // apply gravity
        if (!characterController.isGrounded)
        {
            gravity += Physics.gravity * Time.deltaTime ;
      
        }
        else
        {
            gravity = Vector3.down ;
        }
        // flip
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && abilityDoubleJump)
        {
            abilityDoubleJump = false;
            gravity = Vector3.up * jumpPower ;
            animator.SetTrigger(FlipHash);
            EffectManager.instance.JumpEffect(transform.position + Vector3.up *  0.3f);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            gravity = Vector3.up * jumpPower ;
            animator.SetTrigger(JumpHash);
        }

       


        characterController.Move((v * transform.forward  + h * transform.right)* speed * Time.deltaTime + gravity * Time.deltaTime);

        animator.SetFloat(MoveYHash, v * ((runKey)?2 : 1) );
        animator.SetFloat(MoveXHash, h * ((runKey) ? 2 : 1));
        animator.SetBool(GroundedHash,characterController.isGrounded);

    }

    // check if player fall down to reset level
    void CheckGroundLevel()
    {
        if(transform.position.y < -5)
        {
            if(GameManager.Instance != null)
                GameManager.Instance.ResetLevel();
        }
    }

}
