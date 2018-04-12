using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ui面板位置
/// </summary>
public enum UIShowPos
{
    Normal,
    Hide,
    TipTop,
}


public enum HidePage
{
  Hide,
  Destory
}


/// <summary>
/// 注册事件类型
/// </summary>
public enum EventHandlerType
{
    FishHookCheck,
    UpFinish,
    RestStart,
    PlayingAction,
    Success,
    ClosePage,
    HeadPress,
    TakeAway,
    QRCodeSuccess,
}
/// <summary>
/// 游戏物体类型
/// </summary>
public enum EntityType
{
    Wheel,
    XiaoPang,
}
/// <summary>
/// 动画片段名称
/// </summary>
public enum AnimationName
{
    fishhook_down,
    fishhook_up,
    fishhook_get,
    fishhook_letgo,
}
/// <summary>
/// 语音类型
/// </summary>
public enum VoiceType
{
    One = 1,
    Two,
    Three,
    Four,
    Five,
    Start,
    QRCode,
    End,
}
/// <summary>
/// 协程类型
/// </summary>
public enum IeType
{
    Voice,//语音
    Time,//倒计时
}

public enum EffectType
{
    eff_yanhua,

}

public enum AudioNams
{
    shibai,
    shengli,
    downing2,
}

public enum CallParameter
{
    PaySuccess = 0,
    HeadDown,
    HasBoy,
    NoHas,
    TakeAway,
    NoTakeAway,
    Error,
}





