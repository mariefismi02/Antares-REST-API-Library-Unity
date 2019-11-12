using System.Collections;
using UnityEngine;

namespace Proyecto26
{
    public static class StaticCoroutine
    {
        private static CoroutineHolder _runner;

        private static CoroutineHolder runner
        {
            get
            {
                if (_runner == null)
                {
                    _runner = new GameObject("Static Coroutine RestClient").AddComponent<CoroutineHolder>();
                    Object.DontDestroyOnLoad(_runner);
                }

                return _runner;
            }
        }

        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return runner.StartCoroutine(coroutine);
        }

        private class CoroutineHolder : MonoBehaviour
        {
        }
    }
}