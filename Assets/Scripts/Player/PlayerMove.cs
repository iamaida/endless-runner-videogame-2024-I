#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] LayerMask groundLayers;
    public float moveSpeed = 5;
    public float leftRightSpeed = 4;
    private Vector3 velocity;

    static public bool canMove = false;
    // Update is called once per frame
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    public AudioSource runningFX;
    public AudioSource jumpFX;

    private float gravity = -9.81f;
    private CharacterController characterController;

    static public bool isGrounded = false;

    public LayerMask groundMask;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log(isGrounded);
        if (isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Running Jump");
                    runningFX.Stop();
                    jumpFX.Play();
                    runningFX.Play();
                    StartCoroutine(JumSequence());
                }
            }

        }

        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
                transform.Translate(Vector3.forward * Time.deltaTime * 1);
                PlayerMove.isGrounded = false;

            }
            if (comingDown)
            {


                //transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
            }
        }
    }

    IEnumerator JumSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }
}
#endif