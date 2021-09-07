using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Policies; // BehaviourParameters
using Unity.MLAgents.Actuators;

[RequireComponent(typeof(DecisionRequester))]
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

    public override void OnActionReceived(ActionBuffers actions)
    {
        var action = actions.DiscreteActions;
        Debug.LogFormat("[0]={0}, [1]={1}", action[0], action[1]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        /*  Discrete
            전후이동 : 정지/전진/후진 (0, 1, 2)   Non,W,S
            회전처리 : 정지/왼쪽/오른쪽 (0, 1, 2)  Non,A,D
        */

        var actions = actionsOut.DiscreteActions;
        actions.Clear();

        // Branch 0
        if (Input.GetKey(KeyCode.W)) actions[0] = 1;
        if (Input.GetKey(KeyCode.S)) actions[0] = 2;

        // Branch 1
        if (Input.GetKey(KeyCode.A)) actions[1] = 1;
        if (Input.GetKey(KeyCode.D)) actions[1] = 2;

    }
}
