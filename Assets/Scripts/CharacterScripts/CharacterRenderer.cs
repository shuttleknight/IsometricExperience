using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    Vector2 input;
    private Animator characterAnimator;
    private SpriteRenderer characterRenderer;
    private Animation currentAnimation;
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
            currentAnimation = GetComponent<Animation>();
        }
    }

    void SetAnimatorParameters(int HS, int VS)
    {
        characterAnimator.SetInteger("horizontalVelocity", Mathf.Abs(HS));
        characterAnimator.SetInteger("verticalVelocity", VS);
    }
}
