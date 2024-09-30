using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildView : MonoBehaviour
{
    [SerializeField] private GameObject _progressCanvas;
    [SerializeField] private Text _timeText;
    [SerializeField] private Slider _progressSlider;

    private float _progressValue;

    public void SetTimeBuilding(float timeBuilding)
    {
        _progressValue = timeBuilding;
        _progressSlider.maxValue = timeBuilding;
        _progressSlider.value = 0;
    }
   
    public void UpdateProgres(float timeBuilding)
    {
        float minutes = Mathf.FloorToInt(timeBuilding / 60);
        float seconds = Mathf.FloorToInt(timeBuilding % 60);

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        _progressSlider.value = _progressValue - timeBuilding;
    }

    public void EndBuilding()
    {
        _progressCanvas.SetActive(false);
    }
}
