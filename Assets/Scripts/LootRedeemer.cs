using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRedeemer : MonoBehaviour
{

    [SerializeField] private RewardListener _listener;
    [SerializeField] private Reward _reward;

    // Let's say we get rewareded by running the method below.
    public void Rewarded()
    {
        // Signal our rewards.
        _listener.SignalReward(_reward);

        // Prevents signaling this task as completed again.
        Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.gameObject.name == "ship")
        {
            Rewarded();
            Destroy(gameObject);
        }
    }
}
