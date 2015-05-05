#if UNITY_IPHONE

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using System;
using System.Diagnostics;

namespace UnityEditor.XCodeEditor
{
	public class CustomPostprocessScript : MonoBehaviour
	{
		[PostProcessBuild]
		public static void OnPostprocessBuild(BuildTarget target, string pathToBuildProject)
		{ 
	#if UNITY_EDITOR
			XCodeEditor.XCProject project = new XCodeEditor.XCProject( pathToBuildProject );

			// Find and run through all projmods files to patch the project
//			var files = System.IO.Directory.GetFiles( Application.dataPath, "*.projmods", SearchOption.AllDirectories );
//			foreach( var file in files ) {
//				project.ApplyMod( file );
//			}
			;;
			project.ApplyMod( "Assets/Editor/sample_config.projmods" );
			
			// Finally save the xcode project
			project.Save();
	#endif
		}
	}
}

#endif
