using UnityEngine;

public class MainController : MonoBehaviour
{
    private Vector2 VectorToRight = new Vector2(1, 0);
    private Vector2 VectorToLeft = new Vector2(-1, 0);

    public bool OnGround = false;
    public float MoveSpeed = 1;
    public float Jump = 1;
    public Rigidbody2D PlayerRigidbody2D;
    public SpriteRenderer PlayerSpriteRenderer;
    public Animator PlayerAnimation;

    public object PlayerAnimator { get; private set; }

    void Update()
    {
        if (Input.GetKey("d"))
        {
            PlayerMove(VectorToRight);
            RotatePlayer(false);
        }

        else if (Input.GetKey("a"))
        {
            PlayerMove(VectorToLeft);
            RotatePlayer(true);
        }
        else
        {
            AnimationStop();
        }


        if (Input.GetKeyDown("w") == true && OnGround == true)
        {
            PlayerRigidbody2D.AddForce(new Vector2(0, 1) * Jump, ForceMode2D.Impulse);
   
        }

    }
    
    void PlayerMove(Vector2 MoveVector)
    {
        Vector2 NewMoveVector = new Vector2(MoveVector.x * MoveSpeed, PlayerRigidbody2D.velocity.y);
        PlayerRigidbody2D.velocity = NewMoveVector;
        PlayerAnimation.Play("run");
    }
    void RotatePlayer(bool Bool_Value)
    {
        PlayerSpriteRenderer.flipX = Bool_Value;
    }

    void AnimationStop()
    {
        PlayerAnimation.Play("idle");
    }
   
}

