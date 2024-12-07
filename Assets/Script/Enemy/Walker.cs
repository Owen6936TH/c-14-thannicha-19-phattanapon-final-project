using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Walker : Enemy
{

    //Attributes
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    public override void Behavior()
    {
        //Debug.Log("Ant run Brhavior");
        rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }

    }

    private void FlipCharacter()
    {
        velocity *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }

}
