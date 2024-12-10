using UnityEngine;

public class PlayerFeetBoxCast : MonoBehaviour
{
    public MainController MainControllerScript;
    private void OnTriggerStay2D(Collider2D collision)
    {
        MainControllerScript.OnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MainControllerScript.OnGround = false;
    }
}
