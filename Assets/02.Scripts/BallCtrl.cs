using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class BallCtrl : MonoBehaviour
{
    public Agent[] players; // 블루팀 플레이어, 레드팀 플레이어 연결

    private Rigidbody rb;

    // 팀별 스코어 저장 변수
    private int blueScore, redScore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void InitBall()
    {
        rb.velocity = rb.angularVelocity = Vector3.zero;
        transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
    }
}
