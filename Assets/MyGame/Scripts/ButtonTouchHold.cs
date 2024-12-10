using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class ButtonTouchHold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool isHold = false;
    private MainController PlayerControllerScript;

    private void Awake()
    {
        PlayerControllerScript = FindObjectOfType<MainController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
   isHold = true;   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHold = false;

        if (name == "Button Right")
        {
            PlayerControllerScript.isPressedButtonRight = false;
        }
        if (name == "Button Left")
        {
            PlayerControllerScript.isPressedButtonLeft = false;
        }
    }

    private void Update()
    {
        if (isHold == true)
        {
            if (name == "Button Right")
            {
                PlayerControllerScript.isPressedButtonRight = true;
            }
            if (name == "Button Left")
            {
                PlayerControllerScript.isPressedButtonLeft = true;
            }
        }
            
    }

  
}
