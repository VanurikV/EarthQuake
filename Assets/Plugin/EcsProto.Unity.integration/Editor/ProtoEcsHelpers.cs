using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace ProtoTemplate
{
    sealed class TemplateGenerator : ScriptableObject
    {
        const string SystemTemplate = "System.cs.txt";
        const string ComponentTemplate = "Component.cs.txt";

        const string Title = "ProtoECS";
        const string CsIconName = "cs Script Icon";


        [MenuItem("Assets/Create/ProtoECS Proto/System", false, -300)]
        static void CreateStartupSys()
        {
            var assetPath = GetAssetPath();
            CreateAndRenameAsset($"{assetPath}/System.cs", GetIcon(CsIconName),
                (name) => { CreateTemplateInternal(GetTemplateContent(SystemTemplate), name); });
        }


        [MenuItem("Assets/Create/ProtoECS Proto/Component", false, -301)]
        static void CreateStartupCmp()
        {
            var assetPath = GetAssetPath();
            CreateAndRenameAsset($"{assetPath}/Component.cs", GetIcon(CsIconName),
                (name) => { CreateTemplateInternal(GetTemplateContent(ComponentTemplate), name); });
        }
        
        
        
        
        public static string CreateTemplate (string proto, string fileName, Dictionary<string, string> replacements = default) {
            if (string.IsNullOrEmpty (fileName)) {
                return "Ошибочное имя";
            }
            var ns = EditorSettings.projectGenerationRootNamespace.Trim ();
            if (string.IsNullOrEmpty (ns)) { ns = "Client"; }
            replacements ??= new Dictionary<string, string> ();
            replacements.TryAdd ("#NS#", ns);
            replacements.TryAdd ("#SCRIPTNAME#", SanitizeClassName (Path.GetFileNameWithoutExtension (fileName)));
            foreach (var kv in replacements) {
                proto = proto.Replace (kv.Key, kv.Value);
            }
            try {
                File.WriteAllText (AssetDatabase.GenerateUniqueAssetPath (fileName), proto);
            } catch (Exception ex) {
                Debug.LogError (ex.Message);
                return "Ошибка создания файла";
            }
            AssetDatabase.Refresh ();
            return null;
        }
        
        
        static string CreateTemplateInternal(string proto, string fileName,
            Dictionary<string, string> replacements = default)
        {
            var res = CreateTemplate(proto, fileName, replacements);
            if (res != null)
            {
                EditorUtility.DisplayDialog(Title, res, "Закрыть");
            }

            return res;
        }

        static void CreateAndRenameAsset(string fileName, Texture2D icon, Action<string> onSuccess)
        {
            var action = CreateInstance<CustomEndNameAction>();
            action.Callback = onSuccess;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, action, fileName, icon, null);
        }

        
        static string GetTemplateContent (string proto) {
            var pathHelper = CreateInstance<TemplateGenerator> ();
            var path = Path.GetDirectoryName (AssetDatabase.GetAssetPath (MonoScript.FromScriptableObject (pathHelper)));
            DestroyImmediate (pathHelper);
            try {
                return File.ReadAllText (Path.Combine (path ?? "", proto));
            } catch {
                return null;
            }
        }
        
        static string GetAssetPath()
        {
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (!string.IsNullOrEmpty(path) && AssetDatabase.Contains(Selection.activeObject))
            {
                if (!AssetDatabase.IsValidFolder(path))
                {
                    path = Path.GetDirectoryName(path);
                }
            }
            else
            {
                path = "Assets";
            }

            return path;
        }

        
        static string SanitizeClassName (string className) {
            var sb = new StringBuilder ();
            var needUp = true;
            foreach (var c in className) {
                if (char.IsLetterOrDigit (c)) {
                    sb.Append (needUp ? char.ToUpperInvariant (c) : c);
                    needUp = false;
                } else {
                    needUp = true;
                }
            }
            return sb.ToString ();
        }
        

        static Texture2D GetIcon(string iconName) => EditorGUIUtility.IconContent(iconName).image as Texture2D;
    }

    sealed class CustomEndNameAction : EndNameEditAction
    {
        [NonSerialized] public Action<string> Callback;

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            Callback?.Invoke(pathName);
        }
    }
}