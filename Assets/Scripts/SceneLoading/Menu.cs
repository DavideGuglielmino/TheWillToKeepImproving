using UnityEngine;

public enum MenuType
{
    Main_Menu,
    Pause_Menu
}
 
[CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
public class Menu : GameScene
{
    //Settings specific to menu only
    [Header("Menu specific")]
    public MenuType type;
}