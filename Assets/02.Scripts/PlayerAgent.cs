using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Policies; // BehaviourParameters

public class PlayerAgent : Agent
{
    public enum Team
    {
        Blue, Red
    }

    public Team team = Team.Blue;
    public Material[] materials;

    private BehaviorParameters bps;
    private Transform tr;
    private Rigidbody rb;

    public override void Initialize()
    {

    }
}
