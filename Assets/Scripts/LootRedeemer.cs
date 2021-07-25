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

        // Prevents signaling this reward as gained agian.
        //Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("GameObject name: " + gameObject.name);
        Debug.Log("Collider tag: " + collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Rewarded();
        }
    }
}
