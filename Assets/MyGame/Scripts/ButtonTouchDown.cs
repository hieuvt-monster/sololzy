using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTouchDown : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private MainController PlayerControllerScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Button Jump")
        {
            Debug.Log("button is pressed !");
            PlayerControllerScript.PlayerJump();
        }
        if (gameObject.name == "Button Right")
        {
            PlayerControllerScript.PlayerMoveRight();
        }
        if (gameObject.name == "Button Left")
        {
            PlayerControllerScript.PlayerMoveLeft();
        }
        if (gameObject.name == "Button Restart")
        {
            Debug.Log("Game is restarting...");
            PlayerControllerScript.GameRestart();
        }
    }
}