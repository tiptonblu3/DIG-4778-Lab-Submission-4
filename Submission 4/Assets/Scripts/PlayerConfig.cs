using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float speed = 6f;
    public float horizontalLimit = 10f;
    public float verticalLimit = 6f;
    public float attackCooldown = 1f;
}