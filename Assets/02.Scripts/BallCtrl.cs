using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using TMPro;

public class BallCtrl : MonoBehaviour
{
    public Agent[] players; // 블루팀 플레이어, 레드팀 플레이어 연결

    private Rigidbody rb;

    // 팀별 스코어 저장 변수
    private int blueScore, redScore;
    public TMP_Text blueScoreText, redScoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void InitBall()
    {
        rb.velocity = rb.angularVelocity = Vector3.zero;
        transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void OnCollisionEnter(Collision coll)
    {
        // 레드팀 골인
        if (coll.collider.CompareTag("BLUE_GOAL"))
        {
            // Blue -1 Reward
            players[0].AddReward(-1.0f);

            // Red +1 Reward
            players[1].AddReward(+1.0f);

            // Ball Init
            InitBall();

            // Player Init
            players[0].EndEpisode();
            players[1].EndEpisode();

            // 스코어 누적
            ++redScore;
            redScoreText.text = redScore.ToString();
        }

        // 블루팀 골인
        if (coll.collider.CompareTag("RED_GOAL"))
        {
            // Blue +1 Reward
            players[0].AddReward(+1.0f);

            // Red -1 Reward
            players[1].AddReward(-1.0f);

            // Ball Init
            InitBall();

            // Player Init
            players[0].EndEpisode();
            players[1].EndEpisode();

            // 스코어 누적
            ++blueScore;
            blueScoreText.text = blueScore.ToString();
        }
    }
}
