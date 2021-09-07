using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class BallCtrl : MonoBehaviour
{
    public Agent[] players;

    private Rigidbody rb;

    // 팀별 스코어 저장 변수
    private int blueScore, redScore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
