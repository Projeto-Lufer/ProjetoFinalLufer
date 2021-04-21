using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthPointsView : MonoBehaviour
{
    [SerializeField] private Text healthTextUI;
    [SerializeField] private ParticleSystem hitParticles;
    private string baseText;

    void Start()
    {
        baseText = healthTextUI.text;
    }

    public void ReactToDamage(int curHP, int maxHP)
    {
        UpdateHealthUI(curHP, maxHP);
        PlayVisuals();
    }

    public void UpdateHealthUI(int curHP, int maxHP)
    {
        healthTextUI.text = $"{baseText} {curHP}/{maxHP}";
    }

    private void PlayVisuals()
    {
        hitParticles.Play();
    }
}
