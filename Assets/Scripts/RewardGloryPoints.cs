using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardGloryPoints : MonoBehaviour
{
    private int _gloryPoints = 0;

    [SerializeField] private RewardListener _listener;
    [SerializeField] private TextMeshProUGUI gpTextMeshPro;

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

    private void ProcessRewards(Reward rewards)
    {
        _gloryPoints += rewards.gloryPoints;
        Debug.Log("We have this many points: " + _gloryPoints);
        gpTextMeshPro.text = "GP: " + _gloryPoints;
    }
}
