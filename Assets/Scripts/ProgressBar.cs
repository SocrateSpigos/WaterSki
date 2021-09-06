using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiStartText;
    [SerializeField] private Text uiEndText;


    [Header("Player & Endline references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;

    private Vector3 endLinePosition;
    private float fullDistance;
    
    private void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }

    public void SetLevelTexts(int level)
    {

    }


    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, endLinePosition);
    }

    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = 1 - value;
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(0f, fullDistance, newDistance);

        UpdateProgressFill(progressValue);
    }
}
