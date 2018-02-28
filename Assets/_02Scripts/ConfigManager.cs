using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager
{
    public static string M_Path
    {
        get
        {
            return Application.streamingAssetsPath + "/config.xml";
        }
    }

    private static Config m_config;
    public static Config M_Config
    {
        get
        {
            if (m_config == null)
            {
                if (File.Exists(M_Path))
                {
                    m_config = XmlTool.DeserializeObject<Config>(File.ReadAllText(M_Path));
                }
                else
                {
                    m_config = new Config();
                    if (!Directory.Exists(Application.streamingAssetsPath))
                    {
                        Directory.CreateDirectory(Application.streamingAssetsPath);
                    }
                    File.WriteAllText(M_Path, XmlTool.SerializeObject<Config>(m_config));
                    UnityEditor.AssetDatabase.Refresh();
                }
            }
            return m_config;
        }
    }
}

public class Config
{
    public string address = "上海市浦东新区广兰路";
    public int ID = 1;
    public float value = 27.0f;
    public bool isMale = true;
}
