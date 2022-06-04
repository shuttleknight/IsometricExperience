using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMovement : MonoBehaviour
{
    private float velocity = 2f;
    private Vector2 input;

    void Update()
    {
        SetTranslationDirection();
        transform.Translate(input * velocity * Time.deltaTime);
    }

    private void SetTranslationDirection()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical") / 2));
    }
}
