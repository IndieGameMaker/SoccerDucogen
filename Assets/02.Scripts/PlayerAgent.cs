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
        MaxStep = 10000;

        bps = GetComponent<BehaviorParameters>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        // Team ID값을 설정
        bps.TeamId = (int)team;
        // Team Color 변경
        GetComponent<Renderer>().material = materials[(int)team];
    }
}
