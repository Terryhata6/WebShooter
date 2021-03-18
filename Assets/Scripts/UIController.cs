using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject WinPanel;
    public Slider ObjectsSlider;
    public Slider WebContainerSlider;
    public Text WinObjectsText;
    public Text WinCoinText;

    private Counter _counter;
    private int _currentSliderNum;
    private int _currentWebSliderNum;

    private void Awake()
    {
        _counter = FindObjectOfType<Counter>();
    }

    //objects slider
    public void SetMaxSliderNum(int num)
    {
        ObjectsSlider.maxValue = num;
    }
    public void IncreaseSliderNum()
    {
        _currentSliderNum++;
        ObjectsSlider.value = _currentSliderNum;
    }
    public void DicreaseSliderNum()
    {
        _currentSliderNum--;
        ObjectsSlider.value = _currentSliderNum;
    }
    public void ZeroiseSliderNum()
    {
        _currentSliderNum = 0;
        ObjectsSlider.value = _currentSliderNum;
    }

    //web slider
    public void IncreaseToMaxWebSliderNum(int num)
    {
        _currentWebSliderNum = num;
        WebContainerSlider.maxValue = _currentWebSliderNum;
        WebContainerSlider.value = _currentWebSliderNum;
    }
    public void DicreaseWebSliderNum()
    {
        _currentWebSliderNum--;
        WebContainerSlider.value = _currentWebSliderNum;
    }
    public void ActivateWinPanel()
    {
        WinPanel.SetActive(true);
        WinObjectsText.text = _counter.AmountOfCollectedObjects + "/" + _counter.MaxAmountOfObjects + " objects caught";
        WinCoinText.text = ": " +_counter.AmountOfCollectedCoins ;
    }
}
