using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Vector2 inputToSend;
    CharacterMovement movmentToSendTo;
    CharacterRenderer rendererToSendTo;

    void Start() {
        movmentToSendTo = gameObject.GetComponent<CharacterMovement>();
        rendererToSendTo = gameObject.GetComponent<CharacterRenderer>();
    }


    void Update() {
        inputToSend = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        SendInputToRendererAndMovement();
    }

    void SendInputToRendererAndMovement() {
        movmentToSendTo.SetInput(inputToSend);
        rendererToSendTo.SetInput(inputToSend);
    }
}
