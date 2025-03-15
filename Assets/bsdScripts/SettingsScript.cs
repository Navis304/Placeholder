using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public UIManager iManager;
    public void SetTextSpeed(int arg)
    {
        iManager.textSpeedOption = arg;
    }
}
