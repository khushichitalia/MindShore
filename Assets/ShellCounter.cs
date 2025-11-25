using TMPro;
using UnityEngine;

public class ShellCounter : MonoBehaviour
{
    public static ShellCounter instance;
    public TextMeshProUGUI shellText;

    private int count = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        count = 0;
        shellText.text = "Shells: 0";
    }

    public void AddShell()
    {
        count++;
        shellText.text = "Shells: " + count;
    }

    public void RemoveShell()
    {
        count--;
        if (count < 0) count = 0;
        shellText.text = "Shells: " + count;
    }
}
