using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Simulation.Implementation;
using Simulation.Implementation.Components.Behaviours.Monsters;
using Simulation.Implementation.Components.Behaviours.Players;
using Simulation.Implementation.Components.Behaviours.Shells;
using Simulation.Implementation.Components.Services;
using Simulation.Implementation.Factories;
using Simulation.Implementation.Geometry;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Comparers;
using GameObject = UnityEngine.GameObject;
using Vector2 = Simulation.Implementation.Geometry.Vector2;
using Transform = Simulation.Implementation.Components.Transform;

namespace Visualisation
{
    public class GameManager : MonoBehaviour
    {
        public GameObject Unit;
        public GameObject Shell;

        private World _world;

        private List<GameObject> _units;
        private List<GameObject> _shells;
        private List<GameObject> _players;

        private double W = 10;
        private double H = 7.5f;
        private double Scale = 0.02f;

        [UsedImplicitly]
        private void Start()
        {
            // Configure model
            _world = new World();

            for (int i = 0; i < 10; i++)
            {
                var monster = Factory.MakeQuickMonster(_world, new Vector2(50 + 100 * i, 375));
                _world.CreateObject(monster);
            }

            _world.CreateObject(Factory.MakePlayer(_world, new Vector2(100, 100), Math.PI / 4, new SimplePlayer
            {
                Type = PlayerBehaviour.PlayerType.Red
            }));

            _world.CreateObject(Factory.MakePlayer(_world, new Vector2(900, 100), Math.PI / 4, new SimplePlayer
            {
                Type = PlayerBehaviour.PlayerType.Green
            }));

            _world.CreateObject(Factory.MakePlayer(_world, new Vector2(100, 650), Math.PI / 4, new SimplePlayer
            {
                Type = PlayerBehaviour.PlayerType.Blue
            }));

            _world.CreateObject(Factory.MakePlayer(_world, new Vector2(900, 650), Math.PI / 4, new SimplePlayer
            {
                Type = PlayerBehaviour.PlayerType.Yellow
            }));

            // Configure view
            _units = new List<GameObject>();
            _shells = new List<GameObject>();
            _players = new List<GameObject>();

            for (int i = 0; i < 50; i++)
            {
                _units.Add(Instantiate(Unit, Vector3.right * i, Quaternion.identity));
                _shells.Add(Instantiate(Shell, Vector3.right * i, Quaternion.identity));
                _players.Add(Instantiate(Unit, Vector3.right * i, Quaternion.identity));
            }

            Test();
        }

        [UsedImplicitly]
        private void Update()
        {
            _world.DoStep();
            Draw();
        }

        private void Draw()
        {
            // Clear positions
            _units.Concat(_shells).Concat(_players)
                .Select(o => o.GetComponent<UnityEngine.Transform>())
                .ToList()
                .ForEach(t =>
                {
                    t.localPosition = new Vector3(-3, -3, 0);
                });

            // Place units
            var units = _world.GetObjects<MonsterBehaviour>().ToList();

            for (var i = 0; i < units.Count; i++)
            {
                MapTransform(units[i], _units[i]);
                _units[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            // Place shells
            var shells = _world.GetObjects<ShellBehaviour>().ToList();

            for (var i = 0; i < shells.Count; i++)
            {
                MapTransform(shells[i], _shells[i]);
                _shells[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            // Place players
            var players = _world.GetObjects<PlayerBehaviour>().ToList();

            for (var i = 0; i < players.Count; i++)
            {
                MapTransform(players[i], _players[i]);
                _players[i].GetComponent<Renderer>().material.color = Color.black;
            }
        }

        private void MapTransform(Simulation.Implementation.GameObject source, GameObject dest)
        {
            SizeService sizeService = source.World
                .GetObject<SizeService>()
                .GetComponent<SizeService>();

            // Pos
            float x = (float) (W / sizeService.Size.X * source.GetComponent<Transform>().Position.X);
            float y = (float) (-1 * H / sizeService.Size.Y * source.GetComponent<Transform>().Position.Y);

            dest.transform.position = new Vector3(x, y, 0);

            // Rot
            float angle = (float) (source.GetComponent<Transform>().Angle * -1 * Mathf.Rad2Deg);
            dest.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Scale
            float scale = (float) (Scale * source.GetComponent<Transform>().Radius);
            dest.transform.localScale = new Vector3(scale, scale, scale);
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
            Assert.AreEqual(u, u2);

            //
            var l = new Vector2(-1, 0);
            var l2 = Vector2.FromAngle(Mathf.PI);
            Assert.AreEqual(l, l2);

            //
            var d = new Vector2(0, -1);
            var d2 = Vector2.FromAngle(Mathf.PI * 3 / 2);
            Assert.AreEqual(d, d2);

            Assert.AreEqual((float)r.AngleTo(u), Mathf.PI / 2, "", new FloatComparer((float) Tools.Epsilon));
            Assert.AreEqual((float)u.AngleTo(l), Mathf.PI / 2, "", new FloatComparer((float) Tools.Epsilon));
            Assert.AreEqual((float)l.AngleTo(d), Mathf.PI / 2, "", new FloatComparer((float) Tools.Epsilon));
            Assert.AreEqual((float)d.AngleTo(r), Mathf.PI / 2, "", new FloatComparer((float) Tools.Epsilon));

            Assert.AreEqual((float)l.AngleTo(u), -Mathf.PI / 2, "", new FloatComparer((float) Tools.Epsilon));

            Assert.AreEqual((float)l.AngleTo(r), Mathf.PI, "", new FloatComparer((float) Tools.Epsilon));

            Debug.Log("Tests completed");
        }
    }
}
