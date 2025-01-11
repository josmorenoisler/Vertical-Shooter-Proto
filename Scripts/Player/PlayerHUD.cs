using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VerticalShooter
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] Image fuelBar;
        [SerializeField] TextMeshProUGUI scoreText;

        void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
            fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
            scoreText.text = $"Score: {GameManager.Instance.GetScore()}";
        }
    }
}
