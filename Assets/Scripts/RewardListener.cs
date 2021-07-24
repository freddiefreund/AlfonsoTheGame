using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardListener : MonoBehaviour
{
    public event Action<Reward> OnRewards;

    public void SignalReward(Reward reward)
    {
        OnRewards?.Invoke(reward);
        Debug.Log("The reward " + reward.name + " was given!");
    }


    /*

    -- Example Usage: Rewards --

    // This variable will be set in the inspector
    [SerializeField] private RewardsListener _listener;
    [SerializeField] private Rewards _rewards;

    // Let's say we get rewareded by running the method below.
    public void Rewarded()
    {
        // Signal our rewards.
        _listener.SignalReward(_rewards);

        // Prevents signaling this task as completed again.
        Destroy(this);
    }

    -- Example Usage: Using the Callback --

    // This variable will be set in the inspector.
    [SerializeField] private RewardsListener _listener;

    private void OnEnable()
    {
        // registering the event to a method, so the listener knows what to call.
        _listener.OnRewards += ProcessRewards;
    }

    private void OnDisable()
    {
        // we don't want `ProcessRewards(...)` to run if our component is disabled,
        // so we remove the callback from the listener.
        _listener.OnRewards -= ProcessRewards;
    }

    private void ProcessRewards(Rewards rewards)
    {
        // do something with the rewards!
    }


 */
}
