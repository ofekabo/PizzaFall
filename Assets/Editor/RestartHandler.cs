using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

/// <summary>
/// use F7 Key to restart you're game, runs automaticly . !!Place on Editor Folder!!
/// </summary>


///<summary>
/// The "Broken Lightning Effect" only happens in editor so dont worry about your build.
/// </summary>

public class RestartHandler
{
    
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        GameObject go = Object.Instantiate(new GameObject(),new Vector3(0,0,0),Quaternion.identity);
        go.AddComponent<GO>();
    }
}
#if UNITY_EDITOR
public class GO : MonoBehaviour
    {
        // Change the Keycode.(KEY) here to change ur default key for restart
        public const KeyCode DefualtKey = KeyCode.F7;
        KeyCode _selectedHotkey;
        void Awake()
        {
            DontDestroyOnLoad(this);
            string json = File.ReadAllText(Application.dataPath + "PreferedHotkeys.json");
            _selectedHotkey = JsonUtility.FromJson<KeyCode>(json);
        }
        
        
        private void Update()
        {
            
            if (Input.GetKeyDown(_selectedHotkey) || Input.GetKeyDown(DefualtKey)) // default selectableHotkey 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

      
    }
#endif
public class RestartHotkeys : EditorWindow
{

    public static KeyCode SelectableHotkey;
    
    [MenuItem("Tools/ToulPaw Tools/Restart Hotkey")]
    static void Init()
    {
        RestartHotkeys window = CreateInstance<RestartHotkeys>();
        window.ShowPopup();
        window.position = new Rect(Screen.width / 2, Screen.height/2,250,80);
    }

    private void OnEnable() // loading saved hotkey
    {
        string json = File.ReadAllText(Application.dataPath + "PreferedHotkeys.json"); // reading from json
        SelectableHotkey = JsonUtility.FromJson<KeyCode>(json); // setting the enum on window as the saved keycode
    }

    public void OnGUI()
    {
        // selectableHotkey = savedHotkey;
        GUILayout.BeginHorizontal();
        
        GUILayout.Space(5);
        
        GUILayout.FlexibleSpace();
        
        GUILayout.BeginVertical();
        
        GUILayout.Space(10);
        
        EditorGUIUtility.labelWidth = 70;
        EditorGUIUtility.fieldWidth = 110;
 
        SelectableHotkey = (KeyCode)EditorGUILayout.EnumPopup("Hotkey : ",SelectableHotkey,GUILayout.ExpandWidth(false));


        if (GUILayout.Button("Save & Close"))
        {
            string chosenKeyCode = JsonUtility.ToJson(SelectableHotkey); // saving the selectableHotkey as json format string
            File.WriteAllText(Application.dataPath + "PreferedHotkeys.json", chosenKeyCode); // creating / saving the json file
            Close();
        }
        EditorGUILayout.HelpBox($"Default Hotkey is {GO.DefualtKey}.",MessageType.Info);
        
        
        GUILayout.EndVertical();
        
        GUILayout.FlexibleSpace();
        
        GUILayout.EndHorizontal();
       
    }
}




