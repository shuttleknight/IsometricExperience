using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    Vector2 input;
    private Animator characterAnimator;
    private SpriteRenderer characterRenderer;

    public void SetInput(Vector2 value) {
        input = value;
    }

    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipCharacterAlongXIfFacingThatWay();
        SetAnimatorParameters((int)input.x, YValueMultipliedToAccountForIsometricDistortion());
    }

    int YValueMultipliedToAccountForIsometricDistortion() {
        return (int)(input.y * 2);
    }

    void FlipCharacterAlongXIfFacingThatWay() {
        if (input.x < 0) {
            characterRenderer.flipX = true;
        }
        else {
            characterRenderer.flipX = false;
        }
    }

    void SetAnimatorParameters(int HS, int VS)
    {
        characterAnimator.SetInteger("horizontalVelocity", Mathf.Abs(HS));
        characterAnimator.SetInteger("verticalVelocity", VS);
    }
}
