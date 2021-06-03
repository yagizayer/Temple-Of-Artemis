using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private void Start()
    {
        if (!player) player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x, 100, player.position.z);
    }
}
