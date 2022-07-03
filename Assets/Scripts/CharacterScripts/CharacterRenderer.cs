using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    Vector2 input;
    private Animator characterAnimator;
    private SpriteRenderer characterRenderer;
    private AnimationState currentState;
    float idleFrame;

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
        SetAnimatorParameters((int)input.x, (int)input.y);
        StopAnimationIfIdle();
    }

    void FlipCharacterAlongXIfFacingThatWay() {
        if (input.x < 0) {
            characterRenderer.flipX = true;
        }
        else if (input.x > 0) {
            characterRenderer.flipX = false;
        }
    }

    void StopAnimationIfIdle() {
        if (input == new Vector2(0, 0)) {
            characterAnimator.SetFloat("velocity", 0);
        }
        else {
            characterAnimator.SetFloat("velocity", 1);
        }
    }

    void SetAnimatorParameters(int HS, int VS)
    {
        characterAnimator.SetInteger("horizontalDirection", Mathf.Abs(HS));
        characterAnimator.SetInteger("verticalDirection", VS);
    }
}
