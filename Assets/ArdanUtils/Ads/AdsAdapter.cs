using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsAdapter : MonoBehaviour
{
//    public static AdsAdapter instance;
//    private const bool testAd = false;

//    public int adscount
//    {
//        get => PlayerPrefs.GetInt("ads_count");
//        set => PlayerPrefs.SetInt("ads_count", value);
//    }

//    private void Awake()
//    {
//        if (instance != null)
//        {
//            DestroyImmediate(gameObject);
//            return;
//        }
//        else
//        {
//            instance = this;
//            DontDestroyOnLoad(transform.parent.gameObject);
//            Screen.sleepTimeout = SleepTimeout.NeverSleep;
//#if !UNITY_EDITOR
//        if (!Debug.isDebugBuild)
//        {
//            Debug.unityLogger.logEnabled = false;
//        }
//#endif
//            Init();
//        }
//    }

//    void Start()
//    {
//    }

//    public void Init()
//    {
//        //if (!testAd)
//        {
//            // FMediation_Adapter.bannerBackgroundColor = new Color(0, 0, 0, 0);
//            // FMediation_AdaptSwitcher.Setup(true);
//        }
//    }

//    public void ShowBanner()
//    {
//        //if (!testAd)
//        {
//            // FMediation_AdaptSwitcher.ShowBanner();
//        }
//    }

//    public void HideBanner()
//    {
//        //if (!testAd)
//        {
//            // FMediation_AdaptSwitcher.HideBanner();
//        }
//    }

//    public void ShowInterstitial()
//    {
//        //if (!testAd)
//        {
//            var level = UIController.instace.level_unlock + 1;
//            if (level <= 3)
//            {
//                return;
//            }

//            adscount++;
//            // FMediation_AdaptSwitcher.ShowInterstitial("Home", level);
//            // if (FMediation_AdaptSwitcher.IsInterstitialReady)
//            // {
//            //     UIController.LogAFAndFB("falcon_game_ad_opened_interstitial", "level", level.ToString());
//            // }
//            UIController.LogAFAndFB("falcon_game_ad_show", "level", level.ToString());

//        }
//    }

//    public void ShowRewardedVideo(Action onComplete, Action onFail, string where)
//    {
//        //if (!testAd)
//        {
//            adscount++;
//            var level = UIController.instace.level_unlock;
//            onComplete += () =>
//            {
//                UIController.LogAFAndFB("falcon_game_ad_completed_rewarded_video", "level", level.ToString());
//            };
//            UIController.LogAFAndFB("falcon_game_ad_opened_rewarded_video", "level", level.ToString());
//            UIController.LogAFAndFB("falcon_game_ad_show", "level", level.ToString());
            
//            // FMediation_AdaptSwitcher.ShowRewardedVideo(onComplete, onFail, where, level);
//        }
//    }
}