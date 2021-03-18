using UnityEngine;

public class WebContainer : MonoBehaviour
{
    public int MaxAmountOfWebShooting;
    private int _currentAmountOfWebShooting;
    private UIController _uiController;

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();
        _uiController.IncreaseToMaxWebSliderNum(MaxAmountOfWebShooting);
        _currentAmountOfWebShooting = MaxAmountOfWebShooting;
    }
    public void DecreaseWebAmount()
    {
        _currentAmountOfWebShooting--;
        _uiController.DicreaseWebSliderNum();
    }
    public bool CheckWeb()
    {
        if(_currentAmountOfWebShooting > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
