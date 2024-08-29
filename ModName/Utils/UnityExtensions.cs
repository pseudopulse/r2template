using UnityEngine;
using System;
using Unity;
using System.Linq;

namespace RaindropLobotomy.Utils
{
    public static class UnityExtensions
    {
        public static void RemoveComponent<T>(this GameObject self) where T : Component
        {
            Object.Destroy(self.GetComponent<T>());
        }

        public static void RemoveComponents<T>(this GameObject self) where T : Component
        {
            T[] coms = self.GetComponents<T>();
            for (int i = 0; i < coms.Length; i++)
            {
                Object.Destroy(coms[i]);
            }
        }

        public static ParticleSystemRenderer FindParticle(this GameObject self, string name) {
            return FindComponent<ParticleSystemRenderer>(self, name);
        }

        public static T FindComponent<T>(this GameObject self, string name) where T : Component {
            return self.GetComponentsInChildren<T>().FirstOrDefault(x => x.gameObject.name == name);
        }

        public static T Clone<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }

        public static void MakeAbideByScale(this ParticleSystem self) {
            ParticleSystem.MainModule main = self.main;
            main.scalingMode = ParticleSystemScalingMode.Hierarchy;
        }

        public static void MakeAbideByScaleRecursively(this GameObject self) {
            foreach (ParticleSystem system in self.GetComponentsInChildren<ParticleSystem>()) {
                system.MakeAbideByScale();
            }
        }

        public static Vector3 Nullify(this Vector3 self, bool x, bool y, bool z) {
            return new Vector3(x ? 0f: self.x, y ? 0f : self.y, z ? 0f : self.z);
        }

        public static void RemoveComponent<T>(this Component self) where T : Component
        {
            Object.Destroy(self.GetComponent<T>());
        }

        public static void RemoveComponents<T>(this Component self) where T : Component
        {
            T[] coms = self.GetComponents<T>();
            for (int i = 0; i < coms.Length; i++)
            {
                Object.Destroy(coms[i]);
            }
        }

        public static T AddComponent<T>(this Component self) where T : Component
        {
            return self.gameObject.AddComponent<T>();
        }

        public static Sprite MakeSprite(this Texture2D self)
        {
            return Sprite.Create(new(0, 0, 512, 512), new(512 / 2, 512 / 2), 1, self);
        }
    }
}