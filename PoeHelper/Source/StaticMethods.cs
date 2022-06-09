using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PoeHelper.Source
{
	public static class StaticMethods
	{
		#region External methods

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
		#endregion

		public static bool IsWindowForeground(string processName)
		{
			uint procId = 0;
			GetWindowThreadProcessId(GetForegroundWindow(), out procId);
			Process activeProc = Process.GetProcessById((int)procId);

			return processName == activeProc.ProcessName || activeProc.ProcessName == "PoeHelper";
		}
	}
}