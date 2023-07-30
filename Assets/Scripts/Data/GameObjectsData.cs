using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameData", menuName = "Game Objects Data")]
public class GamesObjectsData : ScriptableObject
{
    [Header("Player")]
    public Player _player;

    public Material material;

    [Header("Level")]
    public LevelManager _levelManager;

    public Ground _ground;
}
