using System.Collections;

namespace Infrastructure
{
    public interface ICoroutineRunner
    {
        public void StartMyCoroutine(IEnumerator coroutine);
    }
}