using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ====
 ==== Class này có chức năng lưu trữ lại các biến, văn bản, sử dụng tại nhiều vị trí
 ====
 */
public class Constrain
{
    #region SceneName
    public const string SN_START = "Start";
    #endregion


    #region TagName
    public const string TAG_PLAYER = "Player";
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_WALLAROUND = "WallAround";
    public const string TAG_ITEM = "Item";
    #endregion

    #region Value game



    // Item/DestroyItem
    public const float ID_timeDes = 0.15f;

    // ListTiles: 
    public const float LT_timeVer = 0.2f;
    public const float LT_timeHor = 0.2f;
    #endregion



    // Item:
    public static readonly Vector3 I_RotateMoveToTile = new Vector3(0, 720, 0);
    public static readonly Vector3 I_RotateMoveToOtherTile = new Vector3(0, 0, 0);
    public static Vector3 I_ScaleMoveToTile = new Vector3(0.5f, 0.5f, 0.5f);
    public static Vector3 I_ScaleFromPlayZone = new Vector3(1f, 1f, 1f);
    public static Vector3 I_ScaleFromMouseOver = new Vector3(1.2f, 1.2f, 1.2f);
    public static float I_TimeOverMouse = 0.1f;

}