using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ProjectBrowserExtensionLabelSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ProjectBrowserExtensionLabelSetting : ScriptableSingleton<ProjectBrowserExtensionLabelSetting>
    {
        [SerializeField] private bool m_isEnable;

        public bool IsEnable => m_isEnable;

        public void Save()
        {
            Save( true );
        }
    }
}