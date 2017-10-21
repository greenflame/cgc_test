using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Simulation.Implementation;
using Simulation.Interfaces;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private World _world;
    private List<GameObject> _players;

    private float W = 10f;
    private float H = -7.5f;

    [UsedImplicitly]
    private void Start()
    {
        _world = new World();

        _players = new List<GameObject>();
        _players.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
    }

    [UsedImplicitly]
    private void Update()
    {
        _world.DoStep();
        Draw();
    }

    private void Draw()
    {
        foreach (var player in _world.Players)
        {
            float x = W / _world.Width * player.SelfControl.X;
            float y = H / _world.Height * player.SelfControl.Y;

            _players[0].transform.position = new Vector3(x, y, 0);
        }
    }
}
