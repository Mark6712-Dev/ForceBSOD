
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForceBSOD
{
    static class Program
    {
        private static uint STATUS_ASSERTION_FAILURE = 0xC0000420;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(5000);
            RtlAdjustPrivilege(19, true, false, out bool PreviousValue);
            NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
        }
        [DllImport("ntdll.dll")]
        private static extern IntPtr RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        private static extern IntPtr NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);
    }
}
