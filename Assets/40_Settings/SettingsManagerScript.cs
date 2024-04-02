using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    public enum PPString
    {
        SoundSfxVol,
        SoundMusVol,
        Level,
    }
    
    public static class Settings
    {
        static Settings()
        {
            // проверяем если ключа не было то создаем
            if (!PlayerPrefs.HasKey(PPString.SoundMusVol.ToString()))
            {
                PlayerPrefs.SetFloat(PPString.SoundMusVol.ToString(), 0.5f);
                PlayerPrefs.Save();
            }

            if (!PlayerPrefs.HasKey(PPString.SoundSfxVol.ToString()))
            {
                PlayerPrefs.SetFloat(PPString.SoundSfxVol.ToString(), 0.5f);
                PlayerPrefs.Save();
            }

            if (!PlayerPrefs.HasKey(PPString.Level.ToString()))
            {
                PlayerPrefs.SetInt(PPString.Level.ToString(), 0);
                PlayerPrefs.Save();
            }
            
        }
        
        public static float GetMusVol()
        {
            return PlayerPrefs.GetFloat(PPString.SoundMusVol.ToString());
        }

        public static float GetSfxVol()
        {
            return PlayerPrefs.GetFloat(PPString.SoundSfxVol.ToString());
        }
        
        public static void SetMusVol(float vol)
        {
            PlayerPrefs.SetFloat(PPString.SoundMusVol.ToString(), vol);
            PlayerPrefs.Save();
        }

        public static void SetSfxVol(float vol)
        {
            PlayerPrefs.SetFloat(PPString.SoundSfxVol.ToString(), vol);
            PlayerPrefs.Save();
        }


        public static void SetLevel(int level)
        {
            PlayerPrefs.SetInt(PPString.Level.ToString(), level);
            PlayerPrefs.Save();
        }

        public static int GetLevel()
        {
            return PlayerPrefs.GetInt(PPString.Level.ToString());
        }
        
    }

