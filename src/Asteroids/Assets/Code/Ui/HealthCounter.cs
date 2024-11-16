using TMPro;
using UnityEngine;

namespace Asteroids.Code.Ui
{
    public sealed class HealthCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private const string TextTemplate = "Health: {0} / {1}";

        public void SetValues(int current, int max) =>
            _text.text = string.Format(TextTemplate, current, max);
    }
}