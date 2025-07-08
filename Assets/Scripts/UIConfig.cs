using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConfig : MonoBehaviour
{
    [SerializeField] private Slider sliderGeneratedAffirmationLength;
    [SerializeField] private TextMeshProUGUI textConstantAffirmationUpdateTime;
    [SerializeField] private TextMeshProUGUI textGeneratedAffirmationLength;
    [SerializeField] private Toggle toggleConstantAffirmations;
    [SerializeField] private Toggle toggleGenerated;
    [SerializeField] private Toggle toggleStatements;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            OnClickClose();
    }

    public void Activate()
    {
        sliderGeneratedAffirmationLength.value = Config.GeneratedAffirmationWordCount;
        textGeneratedAffirmationLength.text = $"Generated Affirmation Word Length: {sliderGeneratedAffirmationLength.value}";
        toggleConstantAffirmations.isOn = Config.ConstantAffirmations;
        toggleGenerated.isOn = Config.Mode == Config.AffirmationMode.Generated;
        toggleStatements.isOn = Config.Mode == Config.AffirmationMode.Stated;

        gameObject.SetActive(true);
    }

    public void OnClickClose()
    {
        Config.Save();
        gameObject.SetActive(false);
    }

    public void SetConstantAffirmations(bool _)
    {
        Config.ConstantAffirmations = toggleConstantAffirmations.isOn;
    }

    public void ToggleAffirmationsGenerated(bool _)
    {
        Config.Mode = toggleGenerated.isOn ? Config.AffirmationMode.Generated : Config.AffirmationMode.Stated;
        toggleStatements.isOn = !toggleGenerated.isOn;
    }

    public void ToggleAffirmationStatements(bool _)
    {
        Config.Mode = toggleStatements.isOn ? Config.AffirmationMode.Stated : Config.AffirmationMode.Generated;
        toggleGenerated.isOn = !toggleStatements.isOn;
    }

    public void SetGeneratedAffirmationLength(int _)
    {
        Config.GeneratedAffirmationWordCount = (int)sliderGeneratedAffirmationLength.value;
        textGeneratedAffirmationLength.text = $"Generated Affirmation Word Length: {sliderGeneratedAffirmationLength.value}";
    }
}
