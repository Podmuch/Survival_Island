using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratorPowerState : MonoBehaviour
{
    public Player Player;
    public Image PowerStateImage;

    public Sprite[] States;

    private int currentCellsDisplayed;

    private void Start()
    {
        currentCellsDisplayed = Player.CollectedCells;
        SetCorrectImage();
    }

    private void Update()
    {
        if(Player.CollectedCells != currentCellsDisplayed)
        {
            currentCellsDisplayed = Player.CollectedCells;
            SetCorrectImage();
        }
    }

    private void SetCorrectImage()
    {
        PowerStateImage.sprite = States[currentCellsDisplayed];
    }
}
