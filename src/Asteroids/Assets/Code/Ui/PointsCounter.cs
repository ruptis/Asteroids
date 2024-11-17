using TMPro;
using UnityEngine;

namespace Asteroids.Code.Ui
{
    public sealed class PointsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private const string TextTemplate = "Points: {0}";

        public void SetPoints(int points) =>
            _text.text = string.Format(TextTemplate, points);
    }
}