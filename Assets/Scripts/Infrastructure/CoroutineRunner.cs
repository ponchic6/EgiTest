using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void StartMyCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}