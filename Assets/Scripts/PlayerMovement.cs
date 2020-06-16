using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower, movementPower, throwPower;
    public Rigidbody2D character;
    public Animator animator;
    public GameObject ballPrefab;
    public Transform target;

    private Vector3 characterScaleForMovingRight, characterScaleForMovingLeft;
    private bool canThrowBall;


    private void Awake()
    {
        characterScaleForMovingRight = transform.localScale;
        characterScaleForMovingLeft = new Vector3(-characterScaleForMovingRight.x, characterScaleForMovingRight.y, characterScaleForMovingRight.z);
        canThrowBall = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MakeCharacterJump();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MakeCharacterMoveRight();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MakeCharacterMoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBallAndThrowOnTarget();
        }
    }

    private void MakeCharacterJump()
    {
        character.AddForce(Vector2.up * jumpPower);
        animator.Play("CharacterJump");
    }

    private void MakeCharacterMoveRight()
    {
        character.transform.localScale = characterScaleForMovingRight;
        character.AddForce(Vector2.right * movementPower);
        canThrowBall = true;
    }

    private void MakeCharacterMoveLeft()
    {
        character.transform.localScale = characterScaleForMovingLeft;
        character.AddForce(Vector2.left * movementPower);
        canThrowBall = false;
    }

    private void GenerateBallAndThrowOnTarget()
    {
        if (canThrowBall)
        {
            GameObject ball = Instantiate(ballPrefab, character.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody2D>().AddForce(throwPower * Vector3.right);
        }
    }
}
