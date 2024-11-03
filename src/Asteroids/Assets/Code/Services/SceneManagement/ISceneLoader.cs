using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Services.SceneManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string sceneName);
    }
}