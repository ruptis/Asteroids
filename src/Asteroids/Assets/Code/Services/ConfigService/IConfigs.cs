using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Services.ConfigService
{
    public interface IConfigs
    {
        UniTask Initialize();
    }
}