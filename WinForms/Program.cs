using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CanteenBoard.WinForms.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Castle.Windsor.Installer;
using Castle.Core.Logging;
using System.Globalization;
using CanteenBoard.Core;

namespace CanteenBoard.WinForms
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static class Program
    {
        private const int SH_SHOW = 5;
        private const int SH_RESTORE = 9;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                bool newInstance = true;
                using (Mutex mutex = new Mutex(true, "1E21AC47-0412-4850-AFE9-C410BF54073F", out newInstance))
                {
                    if (newInstance)
                    {
                        // Install all Windsor Castle components
                        CastleContainer.Instance.Install(FromAssembly.This());

                        // Set language to Slovak by default
                        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sk");
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

                        // Initialize winforms
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm(CastleContainer.Resolve<IFoodProcessor>(), CastleContainer.Resolve<IBoardProcessor>()));
                    }
                    else
                    {
                        // Bring window to foreground
                        BringToForeground();
                    }
                }
            }
            catch (Exception ex)
            {
                CastleContainer.Resolve<ILogger>().Error(ex.ToString());
                CastleContainer.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Brings window to foreground.
        /// </summary>
        private static void BringToForeground()
        {
            Process me = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(me.ProcessName))
            {
                if (process.Id != me.Id)
                {
                    if (IsIconic(process.MainWindowHandle))
                        ShowWindow(process.MainWindowHandle, SH_RESTORE);
                    else
                        ShowWindow(process.MainWindowHandle, SH_SHOW);

                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
