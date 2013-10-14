using UnityEngine;
using System.Collections;

public class PressHandler : MonoBehaviour {

    public Transform fallingPress;
    public Transform handlePress;
    public Transform topPress;
    private float handleLength = 1;
    private float pressMovedLength = 0;
    Vector3 startPositionOfFallingPress;

    enum PressState
    {
        DESCEND,
        SLOW_ASCEND,
        ASCEND
    };

    private const float descendSpeedMultiplier = 2;
    private const float ascendSpeedMultiplier = 0.5f;
    private const float slowAscendSpeedMultiplier = 0.1f;
    private float speedAccelerator = 0.0f;

    PressState pressState; 


	// Use this for initialization
	void Start () {
        startPositionOfFallingPress = topPress.localPosition - new Vector3(0,topPress.localScale.y,0);
        pressState = PressState.DESCEND;
        fallingPress.position = startPositionOfFallingPress;

        handlePress.localScale = new Vector3(handlePress.localScale.x, 0.2f, handlePress.localScale.z);
        handlePress.localPosition = startPositionOfFallingPress;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPositionOfFallingPress = startPositionOfFallingPress;
        float moveStep = handleLength * Time.deltaTime;
        switch(pressState) 
        {
            case PressState.DESCEND: 
                pressMovedLength += moveStep * descendSpeedMultiplier;
                break;
            case PressState.ASCEND:
                speedAccelerator = 0.0f;
                pressMovedLength -= moveStep * ascendSpeedMultiplier;
                break;
            case PressState.SLOW_ASCEND:
                pressMovedLength -= moveStep * (slowAscendSpeedMultiplier + speedAccelerator);
                speedAccelerator += 0.01f;
                break;
        }
            

        if (pressMovedLength > handleLength)
            pressState = PressState.SLOW_ASCEND;
        if (pressState == PressState.SLOW_ASCEND && pressMovedLength < 0.8)
            pressState = PressState.ASCEND;
        if (pressMovedLength < 0)
            pressState = PressState.DESCEND;

        newPositionOfFallingPress.y -= pressMovedLength;
        fallingPress.localPosition = newPositionOfFallingPress;

        float newHandleLenght = startPositionOfFallingPress.y - fallingPress.localPosition.y;
        handlePress.localScale = new Vector3(handlePress.localScale.x, newHandleLenght, handlePress.localScale.z);
        handlePress.localPosition = topPress.localPosition - new Vector3(0, handlePress.localScale.y / 2 + topPress.localScale.y/2, 0);
 	}
}
