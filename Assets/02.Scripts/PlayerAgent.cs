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

    // 플레이어의 초깃값
    private Vector3 initBluePos = new Vector3(-5.5f, 0.5f, 0.0f);
    private Vector3 initRedPos = new Vector3(5.5f, 0.5f, 0.0f);
    private Quaternion initBlueRot = Quaternion.Euler(Vector3.up * 90.0f);
    private Quaternion initRedRot = Quaternion.Euler(-Vector3.up * 90.0f);

    void InitPlayer()
    {
        tr.localPosition = (team == Team.Blue) ? initBluePos : initRedPos;
        tr.localRotation = (team == Team.Blue) ? initBlueRot : initRedRot;
    }

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

    public override void OnEpisodeBegin()
    {
        InitPlayer();
        rb.velocity = rb.angularVelocity = Vector3.zero;
    }
}
