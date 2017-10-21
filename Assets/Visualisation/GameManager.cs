using System.Collections.Generic;
using JetBrains.Annotations;
using Simulation.Implementation;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Comparers;
using Vector2 = Simulation.Implementation.Vector2;

namespace Visualisation
{
    public class GameManager : MonoBehaviour
    {
        private World _world;
        private List<GameObject> _players;

        private float W = 10;
        private float H = -7.5f;

        [UsedImplicitly]
        private void Start()
        {
            _world = new World();

            _players = new List<GameObject>();
            _players.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

            Test();
        }

        [UsedImplicitly]
        private void Update()
        {
            _world.DoStep();
            Debug.Log(_world.Players[0].SelfControl.Angle);
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

        private static void Test()
        {
            //
            var r = new Vector2(1, 0);
            var r2 = Vector2.FromAngle(0);
            Assert.AreEqual(r, r2);

            //
            var u = new Vector2(0, 1);
            var u2 = Vector2.FromAngle(Mathf.PI / 2);
            Assert.AreEqual(u, u2);

            //
            var l = new Vector2(-1, 0);
            var l2 = Vector2.FromAngle(Mathf.PI);
            Assert.AreEqual(l, l2);

            //
            var d = new Vector2(0, -1);
            var d2 = Vector2.FromAngle(Mathf.PI * 3 / 2);
            Assert.AreEqual(d, d2);

            Assert.AreEqual(r.AngleTo(u), Mathf.PI / 2, "", new FloatComparer(Vector2.Epsilon));
            Assert.AreEqual(u.AngleTo(l), Mathf.PI / 2, "", new FloatComparer(Vector2.Epsilon));
            Assert.AreEqual(l.AngleTo(d), Mathf.PI / 2, "", new FloatComparer(Vector2.Epsilon));
            Assert.AreEqual(d.AngleTo(r), Mathf.PI / 2, "", new FloatComparer(Vector2.Epsilon));

            Assert.AreEqual(l.AngleTo(u), -Mathf.PI / 2, "", new FloatComparer(Vector2.Epsilon));

            Assert.AreEqual(l.AngleTo(r), Mathf.PI, "", new FloatComparer(Vector2.Epsilon));
        }
    }
}
