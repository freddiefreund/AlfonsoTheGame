using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rewards", menuName = "RewardSystem/Reward")]
public class Reward : ScriptableObject
{
    public string Name;
    public int gloryPoints;
}
