using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private Vector2 VectorToRight = new Vector2(1, 0);
    private Vector2 VectorToLeft = new Vector2(-1, 0);

    public bool OnGround = false;
    public float MoveSpeed = 1;
    public float WalkSpeed = 1;
    public float RunSpeed = 1;

    public float Jump = 1;
    public Rigidbody2D PlayerRigidbody2D;
    public SpriteRenderer PlayerSpriteRenderer;
    public Animator PlayerAnimation;

    public bool isPressedButtonRight = false;
    public bool isPressedButtonLeft = false;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(0,10);
    }

    public object PlayerAnimator { get; private set; }

    void Update()
    {
        KeyboardController();
        //TouchController();
    }
    void TouchController()
    {
        if (isPressedButtonRight == true)
        {
            PlayerMoveRight();
        }

        else if (isPressedButtonLeft == true)
        {
            PlayerMoveLeft();
        }
        else
        {
            PlayerStopMovement();
        }
    }

    void KeyboardController()
    {
        if (Input.GetKey("d"))
        {
            PlayerMoveRight();
        }

        else if (Input.GetKey("a"))
        {
            PlayerMoveLeft();
        }
        else
        {
            PlayerStopMovement();
        }


        if (Input.GetKeyDown("w") == true)
        {
            PlayerJump();
        }

        if (Input.GetKey("left shift"))
        {
            MoveSpeed = RunSpeed;
        }
        else
        {
            MoveSpeed = WalkSpeed;
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

    public void PlayerMoveRight()
    {
        PlayerMove(VectorToRight);
        RotatePlayer(false);
    }
    public void PlayerMoveLeft()
    {
        PlayerMove(VectorToLeft);
        RotatePlayer(true);
    }
    public void PlayerStopMovement()
    {
        AnimationStop();
    }
    public void PlayerJump()
    {
        if (OnGround == true)
        {
            PlayerRigidbody2D.AddForce(new Vector2(0, 1) * Jump, ForceMode2D.Impulse);

        }
    }

    public void GameRestart()
    {
        string CurrentSceneName = gameObject.scene.name;
        SceneManager.LoadScene(CurrentSceneName);
    }
}

