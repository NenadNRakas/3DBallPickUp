// Namespace Referances
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgentsExamples;
// Acadamy namespace is obsolite use MonoBehaviour
public class PenguinAcademy : Agent
{
    /// <summary>
    /// Gets/sets the current fish speed
    /// </summary>
    public float FishSpeed { get; private set; }

    /// <summary>
    /// Gets/sets the current acceptable feed radius
    /// </summary>
    public float FeedRadius { get; private set; }
    public float FloatProperties;

    /// <summary>
    /// Called when the academy first gets initialized
    /// </summary>
    public override void InitializeAgent()
    {
        FishSpeed = 0f;
        FeedRadius = 0f;

        // Set up code to be called every time the fish_speed parameter changes 
        // during curriculum learning
        //FloatProperties.RegisterCallback("fish_speed", f => { FishSpeed = f; });
        Academy.Instance.FloatProperties.RegisterCallback("fish_speed", f => { FishSpeed = f; });

        // Set up code to be called every time the feed_radius parameter changes 
        // during curriculum learning
        Academy.Instance.FloatProperties.RegisterCallback("feed_radius", f => { FeedRadius = f; });
    }

    public override float[] Heuristic()
    {
        float forwardAction = 0f;
        float turnAction = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            // move forward
            forwardAction = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // turn left
            turnAction = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // turn right
            turnAction = 2f;
        }

        // Put the actions into an array and return
        return new float[] { forwardAction, turnAction };
    }
}
