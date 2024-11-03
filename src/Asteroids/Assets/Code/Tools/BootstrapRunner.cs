using Asteroids.Code.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Code.Tools
{
    public sealed class BootsrapRunner : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectOfType<BootstrapScope>() != null)
                return;

            SceneManager.LoadScene("Bootstrap");
        }
    }
}