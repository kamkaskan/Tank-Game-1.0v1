using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New DifficultySO", menuName = "DifficultySO", order = 52)]
public class DifficultySO : ScriptableObject
{
    [SerializeField] private float playerHpMod;
    [SerializeField] private float aiHpMod;
    [SerializeField] private float aiAccuracy;
    [SerializeField] private float aiSpeedMod;
    [SerializeField] private int pointsPerKill;
    [SerializeField] private int pointsPerTime;
    public float PlayerHpMod {get {return playerHpMod;}}
    public float AiHpMod {get {return aiHpMod;}}
    public float AiAccuracy {get {return aiAccuracy;}}
    public float AiSpeedMod {get {return aiSpeedMod;}}
    public int PointsPerKill {get {return pointsPerKill;}}
    public int PointsPerTime {get {return pointsPerTime;}}
}
