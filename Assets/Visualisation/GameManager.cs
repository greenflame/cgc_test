using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Simulation.Implementation;
using Simulation.Implementation.Components.Behaviours.Monsters;
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

        private float W = 10;
        private float H = 7.5f;
        private float Scale = 1;

        [UsedImplicitly]
        private void Start()
        {
            _world = new World();

            _world.GameObjects.Add(Factory.MakeQuickMonster(_world));

            _units = new List<GameObject>();
            _shells = new List<GameObject>();

            for (int i = 0; i < 10; i++)
            {
                _units.Add(Instantiate(Unit, Vector3.right * i, Quaternion.identity));
                _shells.Add(Instantiate(Shell, Vector3.right * i, Quaternion.identity));
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
            var units = _world.GetObjects<MonsterBehaviour>().ToList();

            for (var i = 0; i < units.Count; i++)
            {
                MapTransform(units[i], _units[i]);
                _units[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            var shells = _world.GetObjects<ShellBehaviour>().ToList();

            for (var i = 0; i < shells.Count; i++)
            {
                MapTransform(shells[i], _shells[i]);
                _shells[i].GetComponent<Renderer>().material.color = Color.yellow;
            }
        }

        void MapTransform(Simulation.Implementation.GameObject source, GameObject dest)
        {
            SizeService sizeService = source.World
                .GetObject<SizeService>()
                .GetComponent<SizeService>();

            // Pos
            float x = W / sizeService.Size.X * source.GetComponent<Transform>().Position.X;
            float y = -1 * H / sizeService.Size.Y * source.GetComponent<Transform>().Position.Y;

            dest.transform.position = new Vector3(x, y, 0);

            // Rot
            float angle = source.GetComponent<Transform>().Angle * -1 * Mathf.Rad2Deg;
            dest.transform.rotation = Quaternion.Euler(0, 0, angle);
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

            Assert.AreEqual(r.AngleTo(u), Mathf.PI / 2, "", new FloatComparer(Tools.Epsilon));
            Assert.AreEqual(u.AngleTo(l), Mathf.PI / 2, "", new FloatComparer(Tools.Epsilon));
            Assert.AreEqual(l.AngleTo(d), Mathf.PI / 2, "", new FloatComparer(Tools.Epsilon));
            Assert.AreEqual(d.AngleTo(r), Mathf.PI / 2, "", new FloatComparer(Tools.Epsilon));

            Assert.AreEqual(l.AngleTo(u), -Mathf.PI / 2, "", new FloatComparer(Tools.Epsilon));

            Assert.AreEqual(l.AngleTo(r), Mathf.PI, "", new FloatComparer(Tools.Epsilon));

            Debug.Log("Tests completed");
        }
    }
}
