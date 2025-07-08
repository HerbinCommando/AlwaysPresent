using TMPro;
using UnityEngine;

public class UISplashScreen : MonoBehaviour
{
    public GameObject button_affirm;
    public TextMeshProUGUI text_affirmation;
    public TextMeshProUGUI text_score;
    public TextMeshProUGUI text_step;
    public UIConfig uiConfig;

    int score = 0;
    int step_idx = 0;

    public void OnEnable()
    {
        Config.Load();

        Affirmations.Load();
        button_affirm.SetActive(!Config.ConstantAffirmations);
        GenSetAffirmationText();
    }

    public void GenSetAffirmationText()
    {
        text_affirmation.text = Config.Mode == Config.AffirmationMode.Stated ? Affirmations.NextStatement : Affirmations.NextGenerated;

        if (++score % 7 == 0)
            ++step_idx;

        text_score.text = score.ToString();
        text_step.text = Affirmations.steps[step_idx];
    }

    public void OnClickSettings()
    {
        uiConfig.Activate();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        button_affirm.SetActive(!Config.ConstantAffirmations);

        if (timer >= interval)
        {
            timer -= interval;
            OnTick();
        }
    }

    private float timer = 0f;
    private const float interval = 0.5f;

    private void OnTick()
    {
        if (Config.ConstantAffirmations)
            GenSetAffirmationText();
    }
}
