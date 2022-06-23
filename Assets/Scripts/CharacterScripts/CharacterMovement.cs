using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float velocity;
    private Vector2 input;

    public void SetInput(Vector2 value) {
        input = value;
    }
    
    void FixedUpdate() {
        transform.Translate(input * velocity * Time.fixedDeltaTime);   
    }
}
