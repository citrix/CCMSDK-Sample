using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Threading;
//using System.Windows.Forms;

namespace CCMSDKAPI
{

    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void CCMConnectionEventCallbackFP(IntPtr CCMConnectionEventContext, int CCMConnectionID, int CCMEventID);

    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void CCMSessionEventCallbackFP(IntPtr CCMSessionEventContext, int CCMSessionID, int CCMEventID);

    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void CCMApplicationEventCallbackFP(IntPtr CCMApplicationEventContext, int CCMSessionID, int CCMApplicationID, int CCMEventID);

    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void CCMSessionSharingEventCallbackFP(IntPtr CCMSessionErrorEventContext, int CCMSessionID1, int CCMSessionID2, int CCMEventID);

    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void CCMSessionErrorEventCallbackFP(IntPtr CCMSessionErrorEventContext, int CCMSessionID, int unknowInt, int CCMSessionErrorEventID, string CCMErrorMessage);

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class CCM_ICASession
    {

        /// int
        public int SessionID;

        /// int
        public int ConnectionID;

        ///// wchar_t[257]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=257)]
        //public string FriendlyName;

        ///// wchar_t[257]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=257)]
        //public string NonSeamlessAppTitle;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string FriendlyName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string NonSeamlessAppTitle;

        /// unsigned int
        //public uint IsSecure;

        /// unsigned int
        public uint IsFullScreen;

        /// unsigned int
        public uint Ssl;

        ///// wchar_t[38]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=38)]
        //public string EncryptionLevel;

        ///// wchar_t[65]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=65)]
        //public string EngineVersion;

        ///// wchar_t[65]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=65)]
        //public string ServerName;

        ///// wchar_t[257]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=257)]
        //public string UserName;

        ///// wchar_t[257]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=257)]
        //public string DomainName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string EncryptionLevel;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string EngineVersion;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string ServerName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string UserName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string DomainName;

        /// unsigned int
        public uint RxFrameCount;

        /// unsigned int
        public uint TxFrameCount;

        /// unsigned int
        public uint RxByteCount;

        /// unsigned int
        public uint TxByteCount;

        /// unsigned int
        public uint RxFrameErrorCount;

        /// unsigned int
        public uint TxFrameErrorCount;

        /// unsigned int
        public uint SeamlessMode;

        /// unsigned int
        public uint ZlMode;

        /// unsigned int
        public uint CGP;

        /// unsigned int
        public uint SpeedBrowseEnabled;

        /// unsigned int
        public uint LastLatency;

        /// unsigned int
        public uint AverageLatency;

        /// unsigned int
        public uint RoundTripDeviation;

        /// unsigned int
        public uint HRes;

        /// unsigned int
        public uint VRes;

        /// unsigned int
        public uint ColorDepth;

        /// unsigned int
        //public uint CSGAddress;
        public uint AudioEnabled;
        /// unsigned int
        //public uint FileAccess;
        public uint PdaEnabled;

        /// unsigned int
        //public uint AudioAccess;
        public uint TwnEnabled;
        /// unsigned int
        //public uint PDAAccess;

        /// unsigned int
        public uint PnpEnabled;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class CCM_ICASession_V2
    {

        /// int
        public int SessionID;

        /// int
        public int ConnectionID;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string FriendlyName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string NonSeamlessAppTitle;

        /// unsigned int
        public uint IsFullScreen;

        /// unsigned int
        public uint Ssl;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string EncryptionLevel;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string EngineVersion;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string ServerName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string UserName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string DomainName;

        /// unsigned int
        public uint RxFrameCount;

        /// unsigned int
        public uint TxFrameCount;

        /// unsigned int
        public uint RxByteCount;

        /// unsigned int
        public uint TxByteCount;

        /// unsigned int
        public uint RxFrameErrorCount;

        /// unsigned int
        public uint TxFrameErrorCount;

        /// unsigned int
        public uint SeamlessMode;

        /// unsigned int
        public uint ZlMode;

        /// unsigned int
        public uint CGP;

        /// unsigned int
        public uint SpeedBrowseEnabled;

        /// unsigned int
        public uint LastLatency;

        /// unsigned int
        public uint AverageLatency;

        /// unsigned int
        public uint RoundTripDeviation;

        /// unsigned int
        public uint HRes;

        /// unsigned int
        public uint VRes;

        /// unsigned int
        public uint ColorDepth;

        /// unsigned int
        //public uint CSGAddress;
        public uint AudioEnabled;
        /// unsigned int
        //public uint FileAccess;
        public uint PdaEnabled;

        /// unsigned int
        //public uint AudioAccess;
        public uint TwnEnabled;

        /// unsigned int
        public uint PnpEnabled;

        //unsigned int
        public uint NewUrlRedirectionEnabled;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string SSLLSDKComplianceMode;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string ConnectionInfoProtocolVersion;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string ConnectionInfoCipherSuite;
        
        //unsigned int
        public uint PeerCertificateCount;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string Certificate0TempPath;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string CertificateTempPath;

        //unsigned int
        public uint CertificateBuffer;

    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CCM_ICAApplication
    {

        /// int
        public int ApplicationID;

        /// int
        public int SessionID;

        ///// wchar_t[257]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 257)]
        //public string FriendlyName;

        ///// wchar_t[257]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 257)]
        //public string Title;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string FriendlyName;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string Title;

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string ClassName;

        /// unsigned int
        public uint IconSize;

        /// unsigned char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string IconData;

        /// unsigned int
        public uint hIcon;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CCM_WF_ReconnectSettingData
    {
        public uint CGP_Title;

        public uint CGP_WarnTime;

        public ushort CGPSessionReliabilityVersion;

        public ushort CGPSessionReliabilityUIFlags;

        public ushort CGPSessionReliabilityUIDimmingPercentage;

        public ushort UsAcrTimeout;

        public ushort UsACRUIFlags;

        public ushort UsACRUIDimmingPercentage;

        public ushort UsACREstimatedTCPTimeout;
    }

    public enum CCMSecurityOption
    {
        CCMSecurityOption_FileAccess = 0,
        CCMSecurityOption_AudioAccess = 1,
        CCMSecurityOption_PDAAccess = 2,
        CCMSecurityOption_TWNAccess = 3
    }


    public class Name_Value
    {
        public string Name = "";
        public string Value = "";

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Name_Value_Pair
    {
        /// wchar_t[65]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 130)]
        //public Char[] Name = new Char[130];

        ///// wchar_t[65]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 65)]
        //public string Name;

        ///// wchar_t[257]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 514)]
        //public Char[] Value = new Char[514];

        /// wchar_t*
        //public IntPtr Value;

        /// wchar_t[65]
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string Name;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string Value;

    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CCM_RSApplication
    {
        public int ProcessID;

        /// int
        public int SessionID;

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string FriendlyName;

      
    }

    [SuppressUnmanagedCodeSecurityAttribute]
    public static class UnsafeNativeMethods
    {
        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMInitialize", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //internal static extern long CCMInitialize([MarshalAs(UnmanagedType.LPWStr)] string connectionName);
        public static extern int CCMInitialize([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string pwcConnectionName);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMUninitialize", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMUninitialize();

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetCCMAttributes", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //internal static extern Int32 CCMGetCCMAttributes(ref Int32 pCount, [OutAttribute()] [MarshalAs(UnmanagedType.LPArray)]Name_Value_Pair[] ppAttributes);
        //public static extern int CCMGetCCMAttributes(ref Int32 pCount, [OutAttribute()] IntPtr ppAttributes);
        public static extern int CCMGetCCMAttributes(ref Int32 pCount, ref IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetMyConnectionID", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetMyConnectionID([OutAttribute()] IntPtr pCCMConnectionID);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMEnumerateConnections", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMEnumerateConnections(ref int pCount, ref IntPtr ppConnections);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSetConnectionAttributes", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSetConnectionAttributes(int hConnection, int count, IntPtr pAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetConnectionAttributes", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetConnectionAttributes(int hConnection, ref int pcount, out IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMDeleteConnectionAttribute", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMDeleteConnectionAttribute(int hConnection, IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMEnumerateApplications", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMEnumerateApplications(ref Int32 pCount, ref IntPtr ppICAApplications);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMEnumerateSessions", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMEnumerateSessions(ref Int32 pCount, ref IntPtr ppICASessions);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFreeMemory", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern void CCMFreeMemory(System.IntPtr pVoid);

        //[DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFreeAttribute", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //public static extern void CCMFreeAttribute(int count, IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFreeNameValuePair", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern void CCMFreeNameValuePair(int count, IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFreeICASession", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern void CCMFreeICASession(int count, IntPtr pSession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFreeICAApplication", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern void CCMFreeICAApplication(int count, IntPtr pApplication);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMLaunchApplication", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //public static extern int CCMLaunchApplication(int count, IntPtr pParams, ref int hSession);
        public static extern int CCMLaunchApplication(int count, IntPtr pParams, IntPtr hSession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMTerminateApplication", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMTerminateApplication(int hApplication);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetApplicationInfo", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetApplicationInfo(Int32 hApplication, out IntPtr ppICAApplications);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSubscribeConnectionEvents", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSubscribeConnectionEvents(Delegate CCMConnectionEventCallbackFP, IntPtr pContext);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSubscribeSessionStateEvents", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSubscribeSessionStateEvents(Delegate CCMSessionEventCallbackFP, IntPtr pContext);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSubscribeSessionSharingEvents", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSubscribeSessionSharingEvents(Delegate CCMSessionSharingEventCallbackFP, IntPtr pContext);


        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSubscribeApplicationEvents", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSubscribeApplicationEvents(Delegate CCMSubscribeApplicationEvents, IntPtr pContext);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSubscribeSessionErrorEvents", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSubscribeSessionErrorEvents(Delegate CCMSubscribeSessionErrorEvents, IntPtr pContext);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetSessionInfo", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetSessionInfo(int hSession, ref IntPtr ppICASession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMDisconnectSession", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMDisconnectSession(int hSession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMLogoffSession", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMLogoffSession(int hSession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMFullScreenSession", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMFullScreenSession(int hSession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMLogoffAllSessions", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMLogoffAllSessions();

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSystrayIconMessage", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSystrayIconMessage(int hApplication, uint message, uint XPos, uint YPos);

        //[DllImport(@"Path", CharSet = CharSet.Auto, EntryPoint = "CCMShowSecurityOptions", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //public static extern int CCMShowSecurityOptions(int hSession, CCMSecurityOption type); 

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMForeGroundApplication", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMForeGroundApplication(int hApplication);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMSetSessionAttributes", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMSetSessionAttributes(int hSession, int count, IntPtr pAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetSessionAttributes", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetSessionAttributes(int hSession, ref int pcount, out IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMDeleteSessionAttribute", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMDeleteSessionAttribute(int hSession, IntPtr ppAttributes);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMDisconnectAllSessions", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMDisconnectAllSessions();

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMDisconnectUserSessions", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMDisconnectUserSessions([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)]String Name, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)]String Domain);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetActiveSessionCount", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetActiveSessionCount(out long count);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetActiveSessionCountForUser", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetActiveSessionCountForUser([InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)]String Name, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)]String Domain);
    
        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetSessionInfo_V2", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetSessionInfo_V2(int hSession, ref IntPtr ppICASession);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMGetReconnectSettings", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMGetReconnectSettings(int hSession, ref IntPtr pAttributes);
        
        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMTerminateRSApplication", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMTerminateRSApplication(int pid);

        [DllImport(@"C:\\Program Files (x86)\\Citrix\\ICA Client\\CCMSDK64.dll", CharSet = CharSet.Auto, EntryPoint = "CCMEnumerateRSApplications", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int CCMEnumerateRSApplications(ref Int32 pCount, ref IntPtr ppICASessions);
    }

    public class CCM
    {

        public List<int> applicationIDFromApplicationEvent = new List<int>();
        public int sessionIDFromSessionEvent = -1;
        private bool sessionStateEventReceived = false;
        private bool sessionSharingEventReceived = false;
        public int ccmInitializeResult = -1;
        public int ccmUnInitializeResult = -1;
        public bool SessionStateEventReceived
        {
            get
            {
                return sessionStateEventReceived;
            }
            set
            {
                sessionStateEventReceived = value;
            }
        }
        public bool SessionShareingEventReceived
        {
            get
            {
                return sessionSharingEventReceived;
            }
            set
            {
                sessionSharingEventReceived = value;
            }
        }
        private bool applicationEventReceived = false;
        public bool ApplicationEventReceived
        {
            get
            {
                return applicationEventReceived;
            }
            set
            {

                applicationEventReceived = value;
            }

        }

        private bool clientEventReceived = false;
        public bool ClientEventReceived
        {
            get
            {
                return clientEventReceived;
            }
            set
            {
                clientEventReceived = value;
            }
        }

        private bool sessionTerminated = false;
        public bool SessionTerminated
        {
            get
            {
                return sessionTerminated;
            }
            set
            {
                sessionTerminated = value;
            }
        }
        public enum ICA_Errors
        {
            /// CCM_OK -> (0x0000)
            CCM_OK = 0,

            /// CCM_CLIENT_ERROR_BOTTOM -> (0x0001)
            CCM_CLIENT_ERROR_BOTTOM = 1,



            /// CCM_ERROR_UNEXPECTED -> (0xFFFF)
            CCM_ERROR_UNEXPECTED = 65535,

            /// CCM_ERROR_UNINITIALIZED -> (0xFFFE)
            CCM_ERROR_UNINITIALIZED = 65534,

            /// CCM_ERROR_COMMUNICATION -> (0xFFFD)
            CCM_ERROR_COMMUNICATION = 65533,

            /// CCM_ERROR_OUT_OF_MEMORY -> (0xFFFC)
            CCM_ERROR_OUT_OF_MEMORY = 65532,

            /// CCM_ERROR_INVALID_ARGUMENT -> (0xFFFB)
            CCM_ERROR_INVALID_ARGUMENT = 65531,

            /// CCM_ERROR_AUTHORIZATION_FAILED -> (0xFFFA)
            CCM_ERROR_AUTHORIZATION_FAILED = 65530,

            /// CCM_ERROR_CONNECTION_NOT_FOUND -> (0xFFF9)
            CCM_ERROR_CONNECTION_NOT_FOUND = 65529,

            /// CCM_ERROR_SESSION_NOT_FOUND -> (0xFFF8)
            CCM_ERROR_SESSION_NOT_FOUND = 65528,

            /// CCM_ERROR_APPLICATION_NOT_FOUND -> (0xFFF7)
            CCM_ERROR_APPLICATION_NOT_FOUND = 65527,

            /// CCM_ERROR_ATTRIBUTE_NOT_FOUND -> (0xFFF6)
            CCM_ERROR_ATTRIBUTE_NOT_FOUND = 65526,

            /// CCM_ERROR_BOTTOM -> (0xF000)
            CCM_ERROR_BOTTOM = 61440,

            /// CCMSE_ERROR_BASE -> (0xEFFF)
            CCMSE_ERROR_BASE = 61439,

            /// CCMSE_ERROR_WINDOW_POSITION -> (0xEFFF)
            CCMSE_ERROR_WINDOW_POSITION = 61439,

            /// CCMSE_ERROR_RESIZING_APPLICATION -> (0xEFFE)
            CCMSE_ERROR_RESIZING_APPLICATION = 61438,

            /// CCMSE_ERROR_DRIVER_NOT_LOADED -> (0xEFFD)
            CCMSE_ERROR_DRIVER_NOT_LOADED = 61437,

            /// CCMSE_ERROR_PROPERTY -> (0xEFFC)
            CCMSE_ERROR_PROPERTY = 61436,

            /// CCMSE_ERROR_SCALING -> (0xEFFB)
            CCMSE_ERROR_SCALING = 61435,

            /// CCMSE_ERROR_KB -> (0xEFFA)
            CCMSE_ERROR_KB = 61434,

            /// CCMSE_ERROR_MOUSE -> (0xEFF9)
            CCMSE_ERROR_MOUSE = 61433,

            /// CCMSE_ERROR_HEADLESS_DISABLED -> (0xEFF8)
            CCMSE_ERROR_HEADLESS_DISABLED = 61432,

            /// CCMSE_ERROR_BOTTOM -> (0xE000)
            CCMSE_ERROR_BOTTOM = 57344,

            /// CCM_CLIENT_ERROR_BASE -> (0x3FFF)
            CCM_CLIENT_ERROR_BASE = 16383,

            /// CCM_ERROR_BASE -> (0xFFFF)
            CCM_ERROR_BASE = 65535,

            ICA_Failed_FindSessionWindow = 65536,
            ICA_Failed_MissMatchAppNameOnServer = 65537,

            ICA_Failed_GetCCMSessionStateEvent_Logon = 65538,
            ICA_Failed_GetCCMApplicationEvent_Launch = 65539,
            ICA_Success = 65540,
            ICA_Failed = 65541,
            //ICA_Failed_GetSessionLaunchEvent,
            //ICA_Failed_GetApplicationLaunchEvent,
            ICA_Failed_GetEvents = 65542,
            ICA_Failed_LaunchSession = 65543,
            ICA_Failed_GetCorrectSessionStatus = 65544,
            ICA_Failed_MissMatchApplicationID = 65545,
            ICA_Failed_MissMatchSessionID = 65546,
            ICA_Failed_WrongActiveSessionNumber = 65547,
            ICA_Failed_LogOffSession = 65548,
            ICA_Failed_LogOffAllSessions = 65549,
            ICA_Failed_GetProcessExiteCode = 65550,
            ICA_Failed_LaunchProcess = 65551,
            ICA_Failed_EnumerateSessions = 65552,
            ICA_Failed_RemoveLoggedOffSession = 65553,
            ICA_Failed_GetCCMSessionSharingEvent = 65554,
            ICA_Failed_DisconnectSession = 65555,
            ICA_Failed_TerminateSession = 65556,
            ICA_Failed_FindACRWindow = 65557

        }

        bool waitEvents = false;
        CCMSessionEventCallbackFP sessionEventCallBack;
        CCMApplicationEventCallbackFP applicationEventCallBack;
        CCMConnectionEventCallbackFP connectionEventCallBack;
        CCMSessionSharingEventCallbackFP sessionSharingEventCallBack;

        public List<int> sessionEventIDs = new List<int>();
        public List<int> applicationEventIDs = new List<int>();
        public List<int> sessionIDfromSessionShareEvent = new List<int>();

        public CCM(string connectionName)
        {
            CCMInitialize(connectionName, true);
        }

        public CCM(string connectionName, bool waitForEvents)
        {
            CCMInitialize(connectionName, waitForEvents);
        }
        /// <summary>
        /// Constructor of CCM. In this constructor we will initialize CCM
        /// </summary>
        /// <param name="connectionName"></param>
        public int CCMInitialize(string connectionName, bool waitForEvents)
        {
            ccmInitializeResult = Initialize(connectionName);
            if (ccmInitializeResult != 0)
            {
                return ccmInitializeResult;
            }

            waitEvents = waitForEvents;
            //if (waitForEvents)
            //{
            sessionEventCallBack = OnSessionStateEvents;

            IntPtr pContext1 = new IntPtr();
            CCMSubscribeSessionStateEvents(sessionEventCallBack, pContext1);
            GC.KeepAlive(sessionEventCallBack);
            sessionIDFromSessionEvent = -1;

            applicationEventCallBack = OnApplicationEvents;

            IntPtr pContext2 = new IntPtr();
            CCMSubscribeApplicationEvents(applicationEventCallBack, pContext2);
            GC.KeepAlive(applicationEventCallBack);

            applicationIDFromApplicationEvent.Clear();

            connectionEventCallBack = OnClientEvents;
            IntPtr pContext3 = new IntPtr();
            CCMSubscribeConnectionEvents(connectionEventCallBack, pContext3);
            GC.KeepAlive(connectionEventCallBack);

            sessionSharingEventCallBack = OnSessionSharingEvent;
            IntPtr pContext4 = new IntPtr();
            CCMSubscribeSessionSharingEvents(sessionSharingEventCallBack, pContext4);
            GC.KeepAlive(sessionSharingEventCallBack);
            //}

            return (int)ICA_Errors.ICA_Success;
        }

        /// <summary>
        /// Destructor of CCM. We will uninitialize CCM
        /// </summary>
        ~CCM()
        {
            ccmUnInitializeResult = Uninitialize();

        }

        /// <summary>
        /// Initialize CCM
        /// </summary>
        /// <param name="connectionName"> Connectin Name</param>
        /// <returns></returns>
        public int Initialize(string connectionName)
        {
            try
            {
                int result = UnsafeNativeMethods.CCMInitialize(connectionName);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return CCMError.CCM_ERROR_INITIALIZATION_FAILED;
            }
        }

        /// <summary>
        /// Unitialize CCM
        /// </summary>
        /// <returns></returns>
        public int Uninitialize()
        {
            return UnsafeNativeMethods.CCMUninitialize();
        }

        /// <summary>
        /// Set CCM connection attributes
        /// </summary>
        /// <param name="connectionID">connecitn ID</param>
        /// <param name="numberOfNameValuePair">number of attributes will be set</param>
        /// <param name="nameValuePairs">atttributes which is the array of Name_Value</param>
        /// <returns>CCM return value</returns>
        public int CCMSetConnectionAttributes(int connectionID, int numberOfNameValuePair, Name_Value_Pair[] nameValuePairs)
        {
            for (int i = 0; i < numberOfNameValuePair; i++)
            {
                IntPtr addressOfNameValuePairs = IntPtr.Zero;
                Name_Value_Pair currentAttribute = new Name_Value_Pair();
                currentAttribute.Name = nameValuePairs[i].Name;
                currentAttribute.Value = nameValuePairs[i].Value;

                //addressOfNameValuePairs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
                byte[] pairs = new byte[Marshal.SizeOf(typeof(Name_Value_Pair))];
                GCHandle gch = GCHandle.Alloc(pairs, GCHandleType.Pinned);
                Marshal.StructureToPtr(currentAttribute, gch.AddrOfPinnedObject(), false);



                //Marshal.StructureToPtr(currentAttribute,addressOfNameValuePairs,true);
                //Marshal.StructureToPtr(currentAttribute, addressOfNameValuePairs, true);
                int result = UnsafeNativeMethods.CCMSetConnectionAttributes(connectionID, 1, gch.AddrOfPinnedObject());
                if (result != 0)
                {
                    // Marshal.FreeHGlobal(addressOfNameValuePairs);
                    gch.Free();
                    return result;
                }
                // Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();

            }

            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Set session attribute
        /// </summary>
        /// <param name="sessionID">session Id</param>
        /// <param name="numberOfNameValuePair">number of Name Value Pairs</param>
        /// <param name="nameValuePairs">Name_Value_Pairs</param>
        /// <returns>CCM return value</returns>
        public int CCMSetSessionAttributes(int sessionID, int numberOfNameValuePair, Name_Value_Pair[] nameValuePairs)
        {
            for (int i = 0; i < numberOfNameValuePair; i++)
            {
                IntPtr addressOfNameValuePairs = IntPtr.Zero;
                Name_Value_Pair currentAttribute = new Name_Value_Pair();
                currentAttribute.Name = nameValuePairs[i].Name;
                currentAttribute.Value = nameValuePairs[i].Value;

                //addressOfNameValuePairs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
                byte[] pairs = new byte[Marshal.SizeOf(typeof(Name_Value_Pair))];
                GCHandle gch = GCHandle.Alloc(pairs, GCHandleType.Pinned);
                Marshal.StructureToPtr(currentAttribute, gch.AddrOfPinnedObject(), false);



                //Marshal.StructureToPtr(currentAttribute,addressOfNameValuePairs,true);
                //Marshal.StructureToPtr(currentAttribute, addressOfNameValuePairs, true);
                int result = UnsafeNativeMethods.CCMSetSessionAttributes(sessionID, 1, gch.AddrOfPinnedObject());
                if (result != 0)
                {
                    // Marshal.FreeHGlobal(addressOfNameValuePairs);
                    gch.Free();
                    return result;
                }
                // Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();

            }

            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Get connection attribute by connection ID
        /// </summary>
        /// <param name="connectionID">connection ID</param>
        /// <param name="attributes">this is the out parameter which will return the attributes</param>
        /// <returns>CCM return value</returns>
        public int CCMGetConnectionAttributes(int connectionID, out Name_Value_Pair[] attributes)
        {
            Int32 count = 0;

            // allocate unmananged memory for Name_Value_Pair               
            //var ppAttributes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
            var ppAttributes = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMGetConnectionAttributes(connectionID, ref count, out ppAttributes);
            if (result != 0)
            {
                attributes = null;
                return result;
            }

            attributes = new Name_Value_Pair[count];

            // get the pointer to attributes arry
            //var deref1 = (IntPtr)Marshal.PtrToStructure(ppAttributes, typeof(IntPtr));
            var deref1 = (Int64)ppAttributes;
            for (int i = 0; i < count; i++)
            {
                Name_Value_Pair element = new Name_Value_Pair();
                IntPtr deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(Name_Value_Pair)) * i);
                element = (Name_Value_Pair)Marshal.PtrToStructure(deref2, typeof(Name_Value_Pair));
                attributes[i] = new Name_Value_Pair();
                attributes[i].Value = element.Value;

                attributes[i].Name = element.Name;
                //UnsafeNativeMethods.CCMFreeAttribute(1, deref2);
            }
            //Marshal.FreeHGlobal(ppAttributes);
            UnsafeNativeMethods.CCMFreeNameValuePair(count, ppAttributes);
            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Get session attributes
        /// </summary>
        /// <param name="sessionID">session ID</param>
        /// <param name="attributes">attributes</param>
        /// <returns>CCM return value</returns>
        public int CCMGetSessionAttributes(int sessionID, out Name_Value_Pair[] attributes)
        {
            Int32 count = 0;

            // allocate unmananged memory for Name_Value_Pair               
            //var ppAttributes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
            var ppAttributes = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMGetSessionAttributes(sessionID, ref count, out ppAttributes);
            if (result != 0)
            {
                attributes = null;
                return result;
            }

            attributes = new Name_Value_Pair[count];

            // get the pointer to attributes arry
            //var deref1 = (IntPtr)Marshal.PtrToStructure(ppAttributes, typeof(IntPtr));
            var deref1 = (int)ppAttributes;
            for (int i = 0; i < count; i++)
            {
                Name_Value_Pair element = new Name_Value_Pair();
                IntPtr deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(Name_Value_Pair)) * i);
                element = (Name_Value_Pair)Marshal.PtrToStructure(deref2, typeof(Name_Value_Pair));
                attributes[i] = new Name_Value_Pair();
                attributes[i].Value = element.Value;

                attributes[i].Name = element.Name;
                //UnsafeNativeMethods.CCMFreeAttribute(1, deref2);
            }
            //Marshal.FreeHGlobal(ppAttributes);
            UnsafeNativeMethods.CCMFreeNameValuePair(count, ppAttributes);
            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Delete conneciton attribute on the given connection
        /// </summary>
        /// <param name="connectionID">connection ID</param>
        /// <param name="nameValuePair">the attribue needs to be deleted in the form of Name_Value pair</param>
        /// <returns>CCM return value</returns>
        public int CCMDeleteConnectionAttribute(int connectionID, Name_Value_Pair nameValuePair)
        {
            // allocate unmanaged memory for Name_Value_Pair
            IntPtr addressOfNameValuePairs = IntPtr.Zero;

            //IntPtr addressOfNameValuePairs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
            Name_Value_Pair currentAttribute = new Name_Value_Pair();
            currentAttribute.Value = nameValuePair.Value;


            currentAttribute.Name = nameValuePair.Name;

            byte[] pairs = new byte[Marshal.SizeOf(typeof(Name_Value_Pair))];
            GCHandle gch = GCHandle.Alloc(pairs, GCHandleType.Pinned);
            Marshal.StructureToPtr(currentAttribute, gch.AddrOfPinnedObject(), false);

            // convert from unmanaged memory block to managed attribute object
            //Marshal.StructureToPtr(currentAttribute, addressOfNameValuePairs, true);
            int result = UnsafeNativeMethods.CCMDeleteConnectionAttribute(connectionID, gch.AddrOfPinnedObject());
            if (result != 0)
            {
                //Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();
                return result;
            }
            else
            {
                //Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();
                return CCMError.CCM_OK;
            }

        }

        public int CCMDeleteSessionAttribute(int sessionID, Name_Value_Pair nameValuePair)
        {
            // allocate unmanaged memory for Name_Value_Pair
            IntPtr addressOfNameValuePairs = IntPtr.Zero;

            //IntPtr addressOfNameValuePairs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Name_Value_Pair)));
            Name_Value_Pair currentAttribute = new Name_Value_Pair();
            currentAttribute.Value = nameValuePair.Value;


            currentAttribute.Name = nameValuePair.Name;

            byte[] pairs = new byte[Marshal.SizeOf(typeof(Name_Value_Pair))];
            GCHandle gch = GCHandle.Alloc(pairs, GCHandleType.Pinned);
            Marshal.StructureToPtr(currentAttribute, gch.AddrOfPinnedObject(), false);

            // convert from unmanaged memory block to managed attribute object
            //Marshal.StructureToPtr(currentAttribute, addressOfNameValuePairs, true);
            int result = UnsafeNativeMethods.CCMDeleteSessionAttribute(sessionID, gch.AddrOfPinnedObject());
            if (result != 0)
            {
                //Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();
                return result;
            }
            else
            {
                //Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();
                return CCMError.CCM_OK;
            }

        }

        /// <summary>
        /// Get current connection ID
        /// </summary>
        /// <param name="SessionID">This is the out parameter, it will return the current conneciotn ID</param>
        /// <returns></returns>
        public int CCMGetMyConnectionID(out int ConnectionID)
        {
            IntPtr pConnectionID = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));

            int result = UnsafeNativeMethods.CCMGetMyConnectionID(pConnectionID);
            if (result != 0)
            {
                ConnectionID = -1;
                Marshal.FreeHGlobal(pConnectionID);
                return result;
            }

            //SessionID = (int)Marshal.PtrToStructure(pSessionID, typeof(int));
            ConnectionID = Marshal.ReadInt32(pConnectionID);
            Marshal.FreeHGlobal(pConnectionID);
            return CCMError.CCM_OK;
        }


        /// <summary>
        /// Get all connections IDs
        /// </summary>
        /// <param name="connections">This is the out parameter, it returns all connections ID</param>
        /// <returns>CCM return value</returns>
        public int CCMEnumerateConnections(out int[] connections)
        {
            int count = 0;
            connections = null;
            //var ppConnections = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr))); 
            var ppConnections = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMEnumerateConnections(ref count, ref ppConnections);
            if (result != 0)
            {
                connections = null;
                return result;
            }
            connections = new int[count];
            //var deref1 = (IntPtr)Marshal.PtrToStructure(ppConnections, typeof(IntPtr));
            var deref1 = (Int64)ppConnections;
            for (int i = 0; i < count; i++)
            {
                int currentConnectionID = -1;
                IntPtr deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(int)) * i);

                currentConnectionID = (int)Marshal.PtrToStructure(deref2, typeof(int));
                if (currentConnectionID != -1)
                    connections[i] = currentConnectionID;
                else
                {
                    UnsafeNativeMethods.CCMFreeMemory(ppConnections);
                    return result;
                }

                //UnsafeNativeMethods.CCMFreeMemory(deref2);

            }

            //Marshal.FreeHGlobal((IntPtr)ppConnections);
            UnsafeNativeMethods.CCMFreeMemory(ppConnections);
            return CCMError.CCM_OK;

        }

        /// <summary>
        /// Get all CCM attributes
        /// </summary>
        /// <param name="attributes">This is the out parameter, it will return all CCM attributes in the form of 
        /// Name_Value pair</param>
        /// <returns>CCM return value</returns>
        public int GetCCMAttributes(out Name_Value_Pair[] attributes)
        {
            Int32 count = 0;
            //var ppAttributes = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)));
            var ppAttributes = IntPtr.Zero;
            //var ppAttributes = new IntPtr();
            int result = UnsafeNativeMethods.CCMGetCCMAttributes(ref count, ref ppAttributes);
            if (result != 0)
            {
                attributes = null;
                return result;
            }

            attributes = new Name_Value_Pair[count];
            //var deref1 = (IntPtr)Marshal.PtrToStructure(ppAttributes, typeof(IntPtr));
            var deref1 = (int)ppAttributes;
            for (int i = 0; i < count; i++)
            {
                Name_Value_Pair element = new Name_Value_Pair();
                IntPtr deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(Name_Value_Pair)) * i);
                element = (Name_Value_Pair)Marshal.PtrToStructure(deref2, typeof(Name_Value_Pair));
                //attributes[i] = element;
                attributes[i] = new Name_Value_Pair();
                attributes[i].Value = element.Value;

                // conver char[] to string for name
                //char[] name = new char[65];
                //int index = 0;
                //for (index = 0; index < 130; index = index + 2)
                //{
                //    char currentName = element.Name[index];
                //    if ((currentName.CompareTo('\0') != 0))
                //        name[index / 2] = currentName;

                //    else
                //    {
                //        name[index / 2] = '\0';
                //        if ((element.Name[index + 2].CompareTo('\0') != 0) && (element.Name[index + 4].CompareTo('\0') != 0))
                //            break;
                //    }
                //}
                attributes[i].Name = element.Name;
                //UnsafeNativeMethods.CCMFreeAttribute(1, deref2);            

            }

            //Marshal.FreeHGlobal(ppAttributes);
            UnsafeNativeMethods.CCMFreeNameValuePair(count, ppAttributes);
            return CCMError.CCM_OK;


        }

        /// <summary>
        /// Get all applications information
        /// </summary>
        /// <param name="applications">This is the out parameter, it wil return all applications informaton</param>
        /// <returns>CCM return value</returns>
        public int CCMEnumerateApplications(out CCM_ICAApplication[] applications)
        {
            Int32 count = 0;

            //var ppApplications = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            var ppApplications = IntPtr.Zero;
            //var ppApplications = new IntPtr();
            int result = UnsafeNativeMethods.CCMEnumerateApplications(ref count, ref ppApplications);
            if (result != 0)
            {
                applications = null;
                //Marshal.FreeHGlobal((IntPtr)ppApplications); 
                return result;
            }

            applications = new CCM_ICAApplication[count];
            //var deref1 = (int)Marshal.PtrToStructure(ppApplications, typeof(Int32));

            var deref1 = (Int64)ppApplications;
            //GC.KeepAlive(deref1);
            //Name_Value_Pair element = new Name_Value_Pair();
            //Marshal.PtrToStructure(deref1, element);

            for (int i = 0; i < count; i++)
            {
                CCM_ICAApplication element = new CCM_ICAApplication();
                //byte[] application = new byte[Marshal.SizeOf(typeof(CCM_ICAApplication))];
                //GCHandle gch = GCHandle.Alloc(application, GCHandleType.Pinned);

                var deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(CCM_ICAApplication)) * i);
                //element = (CCM_ICAApplication)Marshal.PtrToStructure(deref2, typeof(CCM_ICAApplication));
                element = (CCM_ICAApplication)Marshal.PtrToStructure(deref2, typeof(CCM_ICAApplication));
                applications[i] = element;
                //UnsafeNativeMethods.CCMFreeApplication(1, deref2);

            }
            //Marshal.FreeHGlobal(ppApplications);
            UnsafeNativeMethods.CCMFreeICAApplication(count, ppApplications);
            return CCMError.CCM_OK;

        }
        //#############Edited#############
        public int CCMEnumerateSessionsSingle(out int session)
        {

            CCM_ICASession[] sessions;
            Console.WriteLine("In CCMEnumerateSessionsSingle function");
            CCMEnumerateSessions(out sessions);
            //session = Marshal.ReadInt32(session);
            session = 0;
            return 0;
        }


        /// <summary>
        /// Get all sessions
        /// </summary>
        /// <param name="sessions">This is the out paramert that will return all sessions</param>
        /// <returns>CCM return value</returns>
        /// 
        public int CCMEnumerateSessions(out CCM_ICASession[] sessions)
        {
            Console.WriteLine("Entry CCMEnumerateSessions function");
            Int32 count = 0;
            // allocate unmanaged memory for the pointer to session array
            //var ppSessions = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCM_ICASession)));
            var ppSessions = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMEnumerateSessions(ref count, ref ppSessions);
            if (result != 0)
            {
                sessions = null;
                //Marshal.FreeHGlobal(ppSessions);
                return result;
            }
            sessions = new CCM_ICASession[count];
            // get the pointer to the session array

            var deref1 = (Int64)ppSessions;
            GC.KeepAlive(deref1);
            for (int i = 0; i < count; i++)
            {
                CCM_ICASession element = new CCM_ICASession();
                int size = Marshal.SizeOf(typeof(CCM_ICASession));
                IntPtr deref2 = (IntPtr)(deref1 + size * i);
                Marshal.PtrToStructure(deref2, element);
                //var deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(CCM_ICAApplication)) * i);
                //element = (CCM_ICAApplication)Marshal.PtrToStructure(deref2, typeof(CCM_ICAApplication));
                //Marshal.PtrToStructure(deref2, element);

                sessions[i] = element;
                //UnsafeNativeMethods.CCMFreeSession(1, deref2);

            }
            //Marshal.FreeHGlobal(ppSessions);
            UnsafeNativeMethods.CCMFreeICASession(count, ppSessions);
            

            // enumerate through session


            return CCMError.CCM_OK;

        }


        public int CCMLaunchApplication(int numberOfNameValuePair, Name_Value_Pair[] nameValuePairs, ref int sessionHandle, bool waitForSessionEvents, bool waitForApplicationEvents, int timeOut, bool waitForSessionSharingEvents)
        {
            int result = CCMLaunchApplication(numberOfNameValuePair, nameValuePairs, ref sessionHandle);
            if (result != CCMError.CCM_OK)
                return result;
            else
            {
                if (waitForSessionEvents && waitForApplicationEvents)
                    Thread.Sleep((TestTimeOut.eventTimeOut - 10) * 1000);
                if (waitForSessionEvents && waitForApplicationEvents)
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("We begin to wait for the session launch related CCM sessions and CCM application event ...");
                    //while (DateTime.Now < t)
                    //{
                    //    //if ((applicationIDFromApplicationEvent.Count != 0) && (sessionIDFromSessionEvent != -1))
                    //    //{
                    //    //    break;
                    //    //}
                    //}
                    //Console.ForegroundColor = ConsoleColor.White;
                    if ((applicationIDFromApplicationEvent.Count != 0) && (sessionIDFromSessionEvent == -1))
                        return (int)ICA_Errors.ICA_Failed_GetEvents;
                    else if (sessionIDFromSessionEvent == -1)
                        return (int)ICA_Errors.ICA_Failed_GetCCMSessionStateEvent_Logon;
                    else if (applicationIDFromApplicationEvent.Count == 0)
                        return (int)ICA_Errors.ICA_Failed_GetCCMApplicationEvent_Launch;


                }
                else if (waitForSessionEvents)
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("We begin to wait for the session launch related CCM session events...");



                    //Console.ForegroundColor = ConsoleColor.White;
                    if (sessionIDFromSessionEvent == -1)
                        return (int)ICA_Errors.ICA_Failed_GetCCMSessionStateEvent_Logon;

                }
                else if (waitForApplicationEvents)
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("We begin to wait for the session launch related CCM application event ...");



                    //Console.ForegroundColor = ConsoleColor.White;
                    if (applicationIDFromApplicationEvent.Count != 0)
                        return (int)ICA_Errors.ICA_Failed_GetCCMApplicationEvent_Launch;

                }
            }
            return CCMError.CCM_OK;
        }
        /// <summary>
        /// Launch Applications by the given name value pairs
        /// </summary>
        /// <param name="numberOfNameValuePair">the number of name value pairs</param>
        /// <param name="nameValuePairs">Name_Value pair array</param>
        /// <param name="sessionHandle">session handle</param>
        /// <returns>CCM return value</returns>
        public int CCMLaunchApplication(int numberOfNameValuePair, Name_Value_Pair[] nameValuePairs, ref int sessionHandle)
        {
            Console.WriteLine("Line 1187");
            IntPtr addressOfSessionHandle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            Console.WriteLine("Line 1189");
            byte[] pairs = new byte[Marshal.SizeOf(typeof(Name_Value_Pair)) * numberOfNameValuePair];
            Console.WriteLine("Line 1191");
            GCHandle gch = GCHandle.Alloc(pairs, GCHandleType.Pinned);

            for (int i = 0; i < numberOfNameValuePair; i++)
            {
                Console.WriteLine("Loop i");
                IntPtr currentPairAddress = (IntPtr)((Int64)gch.AddrOfPinnedObject() + Marshal.SizeOf(typeof(Name_Value_Pair)) * i);
                Name_Value_Pair currentPair = new Name_Value_Pair();
                currentPair.Name = nameValuePairs[i].Name;
                currentPair.Value = nameValuePairs[i].Value;
                Marshal.StructureToPtr(currentPair, currentPairAddress, false);

            }
            Marshal.StructureToPtr(sessionHandle, addressOfSessionHandle, true);
            int result = UnsafeNativeMethods.CCMLaunchApplication(numberOfNameValuePair, gch.AddrOfPinnedObject(), addressOfSessionHandle);
            if (result != 0)
            {
                //Marshal.FreeHGlobal(addressOfNameValuePairs);
                gch.Free();
                Marshal.FreeHGlobal(addressOfSessionHandle);
                return result;
            }
            //sessionHandle = (int)Marshal.PtrToStructure(addressOfSessionHandle, typeof(int));
            Console.WriteLine("Line 1214");
            sessionHandle = (int)Marshal.ReadInt32(addressOfSessionHandle);
            gch.Free();
            Marshal.FreeHGlobal(addressOfSessionHandle);

            return CCMError.CCM_OK;

        }


        /// <summary>
        /// Terminate current launched application by application ID
        /// </summary>
        /// <param name="hApplication">application ID</param>
        /// <returns>CCM return value</returns>
        public int CCMTerminateApplication(int hApplication)
        {
            int result = UnsafeNativeMethods.CCMTerminateApplication(hApplication);
            if (result == 0)
                return CCMError.CCM_OK;
            else
                return result;
        }

        /// <summary>
        /// This is the sample implementation of delegate CCMConnectionEventCallbackFP
        /// </summary>
        /// <param name="CCMConnectionEventContext">onnectionEventContext context</param>
        /// <param name="CCMConnectionID">connectin ID</param>
        /// <param name="CCMEventID">event ID</param>
        public void OnClientEvents(IntPtr CCMConnectionEventContext, int CCMConnectionID, int CCMEventID)
        {
            clientEventReceived = true;

            switch (CCMEventID)
            {
                case (int)CCMClientEventID.CCMClientEvent_Connect:
                    {
                        Console.WriteLine("CCMClientEvent_Connect event received...");
                        Console.WriteLine("Connection ID is: " + CCMConnectionID);
                        break;
                    }
                case (int)CCMClientEventID.CCMClientEvent_Disconnect:
                    {
                        Console.WriteLine("CCMClientEvent_Disconnect event received...");
                        Console.WriteLine("Connection ID is: " + CCMConnectionID);
                        break;
                    }


            }

        }

        /// <summary>
        /// subscribe to connection events
        /// </summary>
        /// <param name="onClientEventsCallBackFC">the call back function for connection events</param>
        /// <param name="pContext">pointer to the context</param>
        public void CCMSubscribeConnectionEvents(Delegate onClientEventsCallBackFC, IntPtr pContext)
        {
            int result = UnsafeNativeMethods.CCMSubscribeConnectionEvents(onClientEventsCallBackFC, pContext);

        }

        public void OnSessionSharingEvent(IntPtr CCMSessionSharingEventContext, int CCMSessionID1, int CCMSessionID2, int EventID)
        {
            sessionIDfromSessionShareEvent.Add(CCMSessionID1);
            sessionIDfromSessionShareEvent.Add(CCMSessionID2);

            SessionShareingEventReceived = true;
            Console.WriteLine("In the OnSessionSharingEvents call....");
            Console.WriteLine("Session 1 ID: " + CCMSessionID1);
            Console.WriteLine("Session 2 ID: " + CCMSessionID2);
            Console.WriteLine("CCMSessionSharingEventID: " + EventID);
            sessionEventIDs.Add((int)CCMSessionSharingEventID.CCMSessionSharingEvent_Success);

            GC.KeepAlive(CCMSessionSharingEventContext);

        }

        public void CCMSubscribeSessionSharingEvents(Delegate onSessionSharingEventsCallBackFC, IntPtr pContext)
        {
            int result = UnsafeNativeMethods.CCMSubscribeSessionSharingEvents(onSessionSharingEventsCallBackFC, pContext);

        }
        /// <summary>
        /// This is the sample code of implementing CCMSessionEventCallbackFP
        /// </summary>
        /// <param name="CCMSessionEventContext">Session Event Context</param>
        /// <param name="CCMSessionID">Session ID</param>
        /// <param name="CCMEventID">Event ID</param>
        public void OnSessionStateEvents(IntPtr CCMSessionEventContext, int CCMSessionID, int CCMEventID)
        {
            sessionIDFromSessionEvent = CCMSessionID;

            sessionStateEventReceived = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (CCMEventID)
            {
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnected:
                    {
                        Console.WriteLine("CCMSessionStateEvent_ACRReconnected recieved ....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnected);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnectFailed:
                    {
                        Console.WriteLine("CCMSessionStateEvent_ACRReconnectFailed received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnectFailed);
                        break;

                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnecting:
                    {
                        Console.WriteLine("CCMSessionStateEvent_ACRReconnecting received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_ACRReconnecting);
                        break;
                    }

                case (int)CCMSessionStateEventID.CCMSessionStateEvent_CGPDisconnect:
                    {
                        Console.WriteLine("CCMSessionStateEvent_CGPDisconnect received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_CGPDisconnect);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_CGPReconnect:
                    {
                        Console.WriteLine("CCMSessionStateEvent_CGPReconnect received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_CGPReconnect);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_ConnectFailed:
                    {
                        Console.WriteLine("CCMSessionStateEvent_ConnectFailed received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_ConnectFailed);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Connecting:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Connecting received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Connecting);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Displayed:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Displayed received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Displayed);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_FullScreen:
                    {
                        Console.WriteLine("CCMSessionStateEvent_FullScreen received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_FullScreen);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Initialized:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Initialized received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Initialized);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_InvalidLicense:
                    {
                        Console.WriteLine("CCMSessionStateEvent_InvalidLicense received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_InvalidLicense);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_LogOn:
                    {
                        Console.WriteLine("CCMSessionStateEvent_LogOn received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_LogOn);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_LogOnFailed:
                    {
                        Console.WriteLine("CCMSessionStateEvent_LogOnFailed received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_LogOnFailed);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_PublishedAppLaunchFailed:
                    {
                        Console.WriteLine("CCMSessionStateEvent_PublishedAppLaunchFailed received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_RefusedByEarlyAuthentication:
                    {
                        Console.WriteLine("CCMSessionStateEvent_RefusedByEarlyAuthentication received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_RefusedByEarlyAuthentication);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_ResolvingApp:
                    {
                        Console.WriteLine("CCMSessionStateEvent_ResolvingApp received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_ResolvingApp);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_SeamlessMode:
                    {
                        Console.WriteLine("CCMSessionStateEvent_SeamlessMode received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_SeamlessMode);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_UserCancelled:
                    {
                        Console.WriteLine("CCMSessionStateEvent_UserCancelled received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_UserCancelled);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Created:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Created received ....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Created);

                        //CCM_ICASession currentSession = null;
                        //int result = CCMGetSessionInfo(CCMSessionID, out currentSession);
                        //if (result == CCMError.CCM_OK)
                        //{
                        //    Console.WriteLine("Session Name: " + currentSession.FriendlyName);
                        //    Console.WriteLine("Domain Name: " + currentSession.DomainName);
                        //}
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Terminated:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Terminated received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Terminated);

                        sessionTerminated = true;
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_PublishedAppLaunched:
                    {
                        Console.WriteLine("CCMSessionStateEvent_PublishedAppLaunched received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_PublishedAppLaunched);
                        break;
                    }
                case (int)CCMSessionStateEventID.CCMSessionStateEvent_Connected:
                    {
                        Console.WriteLine("CCMSessionStateEvent_Connected received....");
                        Console.WriteLine("CCMSessionID: " + CCMSessionID);
                        sessionEventIDs.Add((int)CCMSessionStateEventID.CCMSessionStateEvent_Connected);
                        sessionStateEventReceived = true;
                        break;
                    }

            }
            GC.KeepAlive(CCMSessionEventContext);


        }

        /// <summary>
        /// subscribe to session state change event
        /// </summary>
        /// <param name="onSessionStateEventsCallBackFC">the call back function for session events</param>
        /// <param name="pContext">pointer to context</param>
        public void CCMSubscribeSessionStateEvents(Delegate onSessionStateEventsCallBackFC, IntPtr pContext)
        {
            int result = UnsafeNativeMethods.CCMSubscribeSessionStateEvents(onSessionStateEventsCallBackFC, pContext);

        }

        /// <summary>
        /// This is the sample code on implementing CCMApplicationEventCallbackFP
        /// </summary>
        /// <param name="CCMApplicationEventContext"> Application event context</param>
        /// <param name="CCMApplicationID">application ID</param>
        /// <param name="CCMEventID">event ID</param>
        public void OnApplicationEvents(IntPtr CCMApplicationEventContext, int CCMSessionID, int CCMApplicationID, int CCMEventID)
        {
            //Console.WriteLine("come in the applicatin event part!");
            applicationIDFromApplicationEvent.Add(CCMApplicationID);
            applicationEventReceived = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (CCMEventID)
            {
                case (int)CCMApplicationEventID.CCMApplicationEvent_Launch:
                    {
                        Console.WriteLine("CCMApplicationEvent_Launch received....");
                        Console.WriteLine("CCMApplicationID: " + CCMApplicationID);
                        applicationEventIDs.Add((int)CCMApplicationEventID.CCMApplicationEvent_Launch);
                        CCM_ICAApplication pApplication;

                        int result = CCMGetApplicationInfo(CCMApplicationID, out pApplication);

                        if (result == 0)
                        {
                            Console.WriteLine("Application Name is: " + pApplication.FriendlyName);
                            Console.WriteLine("Application Title is: " + pApplication.Title);

                        }
                        break;

                    }
                case (int)CCMApplicationEventID.CCMApplicationEvent_Terminate:
                    {
                        Console.WriteLine("CCMApplicationEvent_Terminate received....");
                        Console.WriteLine("CCMApplicationID: " + CCMApplicationID);
                        applicationEventIDs.Add((int)CCMApplicationEventID.CCMApplicationEvent_Terminate);
                        break;
                    }
                case (int)CCMApplicationEventID.CCMApplicationEvent_IconChanged:
                    {
                        Console.WriteLine("CCMApplicationEvent_IconChanged received....");
                        Console.WriteLine("CCMApplicationID: " + CCMApplicationID);
                        break;
                    }
                case (int)CCMApplicationEventID.CCMApplicationEvent_TitleChanged:
                    {
                        Console.WriteLine("CCMApplicationEvent_TitleChanged received....");
                        Console.WriteLine("CCMApplicationID: " + CCMApplicationID);
                        applicationEventIDs.Add((int)CCMApplicationEventID.CCMApplicationEvent_TitleChanged);
                        break;
                    }

            }
            GC.KeepAlive(CCMApplicationEventContext);
            //Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Get application information
        /// </summary>
        /// <param name="applicationID">application ID</param>
        /// <param name="application">application information</param>
        /// <returns></returns>
        public int CCMGetApplicationInfo(int applicationID, out CCM_ICAApplication application)
        {
            //var ppApplication = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCM_ICAApplication)));
            var ppApplication = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMGetApplicationInfo(applicationID, out ppApplication);
            if (result != 0)
            {
                application = new CCM_ICAApplication();
                //Marshal.FreeHGlobal(ppApplication);
                return result;
            }
            else
            {
                //CCM_ICAApplication element = new CCM_ICAApplication();
                application = new CCM_ICAApplication();
                //var deref1 = (IntPtr)Marshal.PtrToStructure(ppApplication, typeof(IntPtr));
                application = (CCM_ICAApplication)Marshal.PtrToStructure(ppApplication, typeof(CCM_ICAApplication));
                //UnsafeNativeMethods.CCMFreeApplication(1, deref1);

            }
            //Marshal.FreeHGlobal(ppApplication);
            UnsafeNativeMethods.CCMFreeICAApplication(1, ppApplication);
            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Subscribe to application events
        /// </summary>
        /// <param name="OnApplicationEventsCallBackFC">the call back function for application events</param>
        /// <param name="pContext">pointer to the context</param>
        public void CCMSubscribeApplicationEvents(Delegate OnApplicationEventsCallBackFC, IntPtr pContext)
        {
            int result = UnsafeNativeMethods.CCMSubscribeApplicationEvents(OnApplicationEventsCallBackFC, pContext);

        }


        /// <summary>
        /// Get the session information by session ID
        /// </summary>
        /// <param name="sessionID">session ID</param>
        /// <param name="session">This is the out parameter which will return session information</param>
        /// <returns>CCM return value</returns>
        public int CCMGetSessionInfo(int sessionID, out CCM_ICASession session)
        {
            //var ppSession = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCM_ICASession)));
            var ppSession = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMGetSessionInfo(sessionID, ref ppSession);
            if (result != 0)
            {
                session = null;
                return result;
            }
            else
            {
                //CCM_ICAApplication element = new CCM_ICAApplication();
                session = new CCM_ICASession();
                //var deref1 = (IntPtr)Marshal.PtrToStructure(ppSession, typeof(IntPtr));
                //var deref1 = (int)ppSession;

                session = (CCM_ICASession)Marshal.PtrToStructure(ppSession, typeof(CCM_ICASession));

                //UnsafeNativeMethods.CCMFreeSession(1, deref1);

            }
            //Marshal.FreeHGlobal(ppSession);
            UnsafeNativeMethods.CCMFreeICASession(1, ppSession);
            return CCMError.CCM_OK;
        }

           /// <summary>
        /// Get the session information by session ID
        /// </summary>
        /// <param name="sessionID">session ID</param>
        /// <param name="session">This is the out parameter which will return session information</param>
        /// <returns>CCM return value</returns>
        public int CCMGetSessionInfo_V2(int sessionID, out CCM_ICASession_V2 session)
        {
            //var ppSession = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCM_ICASession)));
            var ppSession = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMGetSessionInfo_V2(sessionID, ref ppSession);
            if (result != 0)
            {
                session = null;
                return result;
            }
            else
            {
                //CCM_ICAApplication element = new CCM_ICAApplication();
                session = new CCM_ICASession_V2();
                //var deref1 = (IntPtr)Marshal.PtrToStructure(ppSession, typeof(IntPtr));
                //var deref1 = (int)ppSession;

                session = (CCM_ICASession_V2)Marshal.PtrToStructure(ppSession, typeof(CCM_ICASession_V2));

                //UnsafeNativeMethods.CCMFreeSession(1, deref1);

            }
            //Marshal.FreeHGlobal(ppSession);
            UnsafeNativeMethods.CCMFreeICASession(1, ppSession);
            return CCMError.CCM_OK;
        }

        /// <summary>
        /// Make the session as a full screen window
        /// </summary>
        /// <param name="sessionID">session ID</param>
        /// <returns>CCM return value</returns>
        public int CCMFullScreenSession(int sessionID)
        {
            int result = UnsafeNativeMethods.CCMFullScreenSession(sessionID);
            return result;

        }
        /// <summary>
        /// Log off the given session
        /// </summary>
        /// <param name="sessionID">session ID</param>
        /// <returns>CCM return value</returns>
        public int CCMLogoffSession(int sessionID)
        {
            int result = UnsafeNativeMethods.CCMLogoffSession(sessionID);
            // wait for CCM update
            if ((waitEvents) && (result == (int)ICA_Errors.CCM_OK))
                Thread.Sleep((TestTimeOut.eventTimeOut - 15) * 1000);
            return result;

        }


        /// <summary>
        /// log off all sessions on the client machine
        /// </summary>
        /// <returns></returns>
        public int CCMLogoffAllSessions()
        {
            int result = UnsafeNativeMethods.CCMLogoffAllSessions();
            //wait for events
            if (waitEvents)
                Thread.Sleep(TestTimeOut.eventTimeOut * 1000);
            return result;

        }
        /// <summary>
        /// Disconnect the given session
        /// </summary>
        /// <param name="sessionID">session Id</param>
        /// <returns>CCM return value</returns>
        public int CCMDisconnectSession(int sessionID)
        {
            int result = UnsafeNativeMethods.CCMDisconnectSession(sessionID);

            return result;

        }


        public int CCMSystrayIconMessage(int hApplication, uint message, uint XPos, uint YPos)
        {

            int result = UnsafeNativeMethods.CCMSystrayIconMessage(hApplication, message, XPos, YPos);
            return result;
        }

        //public int CCMShowSecurityOptions(int hSession, CCMSecurityOption type)
        //{
        //    int result = UnsafeNativeMethods.CCMShowSecurityOptions(hSession, type);
        //    return result;

        //}

        public int CCMForeGroundApplication(int hApplication)
        {
            int result = UnsafeNativeMethods.CCMForeGroundApplication(hApplication);
            return result;

        }

        public int CCMDisconnectAllSessions()
        {
            int result = UnsafeNativeMethods.CCMDisconnectAllSessions();
            return result;
        }
        
        public int CCMDisconnectUserSessions(String Name, String Domain)
        {
            int result = UnsafeNativeMethods.CCMDisconnectUserSessions(Name,Domain);
            return result;
        } 

        public int CCMGetActiveSessionCountForUser(String Name, String Domain)
        {
            int result = UnsafeNativeMethods.CCMGetActiveSessionCountForUser(Name,Domain);
            return result;
        } 

        public int CCMGetActiveSessionCount(out long count){
            int result = UnsafeNativeMethods.CCMGetActiveSessionCount(out count);
            return result;
        }
        public int CCMGetReconnectSettings(int sessionID, out CCM_WF_ReconnectSettingData settings){
            var ppAttributes = IntPtr.Zero;

            int result = UnsafeNativeMethods.CCMGetReconnectSettings(sessionID, ref ppAttributes);
            if (result != 0)
            {
                settings = new CCM_WF_ReconnectSettingData();
                return result;
            }
            else
            {
                settings = new CCM_WF_ReconnectSettingData();
                settings = (CCM_WF_ReconnectSettingData)Marshal.PtrToStructure(ppAttributes, typeof(CCM_WF_ReconnectSettingData));
            }
            return CCMError.CCM_OK;
        }
        public int CCMEnumerateRSApplications(out CCM_RSApplication[] rsApplications)
        {
            Int32 count = 0;
            var ppApplications = IntPtr.Zero;
            int result = UnsafeNativeMethods.CCMEnumerateRSApplications(ref count, ref ppApplications);
            if (result != 0)
            {
                rsApplications = null;
                //Marshal.FreeHGlobal(ppSessions);
                return result;
            }
            rsApplications = new CCM_RSApplication[count];
            var deref1 = (Int64)ppApplications;

            for (int i = 0; i < count; i++)
            {
                CCM_RSApplication element = new CCM_RSApplication();

                var deref2 = (IntPtr)(deref1 + Marshal.SizeOf(typeof(CCM_RSApplication)) * i);
                element = (CCM_RSApplication)Marshal.PtrToStructure(deref2, typeof(CCM_RSApplication));
                rsApplications[i] = element;
                //UnsafeNativeMethods.CCMFreeApplication(1, deref2);

            }
            //Marshal.FreeHGlobal(ppApplications);
            //UnsafeNativeMethods.CCMFreeICAApplication(count, ppApplications);
            return CCMError.CCM_OK;
        }
        public int CCMTerminateRSApplication(int pid)
        {
            int result = UnsafeNativeMethods.CCMTerminateRSApplication(pid);
            if (result == 0)
                return CCMError.CCM_OK;
            else
                return result;
        }
    }
}

public enum CCMSessionStateEventID
{

    /// CCMSessionStateEvent_Created -> 0
    CCMSessionStateEvent_Created = 0,

    /// CCMSessionStateEvent_ConnectFailed -> 1
    CCMSessionStateEvent_ConnectFailed = 1,

    /// CCMSessionStateEvent_InvalidLicense -> 2
    CCMSessionStateEvent_InvalidLicense = 2,

    /// CCMSessionStateEvent_RefusedByEarlyAuthentication -> 3
    CCMSessionStateEvent_RefusedByEarlyAuthentication = 3,

    /// CCMSessionStateEvent_UserCancelled -> 4
    CCMSessionStateEvent_UserCancelled = 4,

    /// CCMSessionStateEvent_ResolvingApp -> 5
    CCMSessionStateEvent_ResolvingApp = 5,

    /// CCMSessionStateEvent_Connecting -> 6
    CCMSessionStateEvent_Connecting = 6,

    /// CCMSessionStateEvent_Connected -> 7
    CCMSessionStateEvent_Connected = 7,

    /// CCMSessionStateEvent_Initialized -> 8
    CCMSessionStateEvent_Initialized = 10,

    /// CCMSessionStateEvent_LogOn -> 9
    CCMSessionStateEvent_LogOn = 8,

    /// CCMSessionStateEvent_LogOnFailed -> 10
    CCMSessionStateEvent_LogOnFailed = 9,

    /// CCMSessionStateEvent_Terminated -> 11
    CCMSessionStateEvent_Terminated = 11,

    /// CCMSessionStateEvent_FullScreen -> 12
    CCMSessionStateEvent_FullScreen = 12,

    /// CCMSessionStateEvent_SeamlessMode -> 13
    CCMSessionStateEvent_SeamlessMode = 13,

    /// CCMSessionStateEvent_Hidden -> 14
    CCMSessionStateEvent_Hidden = 14,

    /// CCMSessionStateEvent_Displayed -> 15
    CCMSessionStateEvent_Displayed = 15,

    /// CCMSessionStateEvent_CGPDisconnect -> 16
    CCMSessionStateEvent_CGPDisconnect = 16,

    /// CCMSessionStateEvent_CGPReconnect -> 17
    CCMSessionStateEvent_CGPReconnect = 17,

    /// CCMSessionStateEvent_ACRReconnecting -> 18
    CCMSessionStateEvent_ACRReconnecting = 18,

    /// CCMSessionStateEvent_ACRReconnected -> 19
    CCMSessionStateEvent_ACRReconnected = 19,

    /// CCMSessionStateEvent_ACRReconnectFailed -> 20
    CCMSessionStateEvent_ACRReconnectFailed = 20,

    /// CCMSessionStateEvent_PublishedAppLaunched -> 21
    CCMSessionStateEvent_PublishedAppLaunched = 21,

    /// CCMSessionStateEvent_PublishedAppLaunchFailed -> 22
    CCMSessionStateEvent_PublishedAppLaunchFailed = 22,
}

public enum CCMClientEventID
{
    CCMClientEvent_Connect = 0,
    CCMClientEvent_Disconnect = 1,
}

public enum CCMSessionSharingEventID
{

    /// CCMSessionSharingEvent_Success -> 0
    CCMSessionSharingEvent_Success = 0,
}

public enum CCMSessionErrorEventID
{

    /// CCMSessionErrorEvent_Error -> 0
    CCMSessionErrorEvent_Error = 0,
}

public enum CCMApplicationEventID
{

    /// CCMApplicationEvent_Launch -> 0
    CCMApplicationEvent_Launch = 0,

    /// CCMApplicationEvent_Terminate -> 1
    CCMApplicationEvent_Terminate = 1,

    /// CCMApplicationEvent_TitleChanged -> 2
    CCMApplicationEvent_TitleChanged = 2,

    /// CCMApplicationEvent_IconChanged -> 3
    CCMApplicationEvent_IconChanged = 3,
}

/// <summary>
/// CCM Error class
/// </summary>
public partial class CCMError
{
    /// CCM_OK -> (0x0000)
    public const int CCM_OK = 0;

    /// CCM_ERROR_BASE -> (0xFFFF)
    public const int CCM_ERROR_BASE = 65535;

    /// CCM_ERROR_UNEXPECTED -> (0xFFFF)
    public const int CCM_ERROR_UNEXPECTED = 65535;

    /// CCM_ERROR_UNINITIALIZED -> (0xFFFE)
    public const int CCM_ERROR_UNINITIALIZED = 65534;

    /// CCM_ERROR_COMMUNICATION -> (0xFFFD)
    public const int CCM_ERROR_COMMUNICATION = 65533;

    /// CCM_ERROR_OUT_OF_MEMORY -> (0xFFFC)
    public const int CCM_ERROR_OUT_OF_MEMORY = 65532;

    /// CCM_ERROR_INVALID_ARGUMENT -> (0xFFFB)
    public const int CCM_ERROR_INVALID_ARGUMENT = 65531;

    /// CCM_ERROR_AUTHORIZATION_FAILED -> (0xFFFA)
    public const int CCM_ERROR_AUTHORIZATION_FAILED = 65530;

    /// CCM_ERROR_CONNECTION_NOT_FOUND -> (0xFFF9)
    public const int CCM_ERROR_CONNECTION_NOT_FOUND = 65529;

    /// CCM_ERROR_SESSION_NOT_FOUND -> (0xFFF8)
    public const int CCM_ERROR_SESSION_NOT_FOUND = 65528;

    /// CCM_ERROR_APPLICATION_NOT_FOUND -> (0xFFF7)
    public const int CCM_ERROR_APPLICATION_NOT_FOUND = 65527;

    /// CCM_ERROR_ATTRIBUTE_NOT_FOUND -> (0xFFF6)
    public const int CCM_ERROR_ATTRIBUTE_NOT_FOUND = 65526;

    /// CCM_ERROR_SRP_NOT_ENABLED -> (0xFFF5)
    public const int CCM_ERROR_SRP_NOT_ENABLED = 65525;

    /// CCM_ERROR_DEAD -> (0xFFF4)
    public const int CCM_ERROR_DEAD = 65524;

    /// CCM_ERROR_INITIALIZATION_FAILED -> (0xFFF3)
    public const int CCM_ERROR_INITIALIZATION_FAILED = 65523;

    /// CCM_ERROR_ALREADY_INITIALIZED -> (0xFFF2)
    public const int CCM_ERROR_ALREADY_INITIALIZED = 65522;


    /// CCM_ERROR_BOTTOM -> (0xF000)
    public const int CCM_ERROR_BOTTOM = 61440;

    /// CCMSE_ERROR_BASE -> (0xEFFF)
    public const int CCMSE_ERROR_BASE = 61439;

    /// CCMSE_ERROR_WINDOW_POSITION -> (0xEFFF)
    public const int CCMSE_ERROR_WINDOW_POSITION = 61439;

    /// CCMSE_ERROR_RESIZING_APPLICATION -> (0xEFFE)
    public const int CCMSE_ERROR_RESIZING_APPLICATION = 61438;

    /// CCMSE_ERROR_DRIVER_NOT_LOADED -> (0xEFFD)
    public const int CCMSE_ERROR_DRIVER_NOT_LOADED = 61437;

    /// CCMSE_ERROR_PROPERTY -> (0xEFFC)
    public const int CCMSE_ERROR_PROPERTY = 61436;

    /// CCMSE_ERROR_SCALING -> (0xEFFB)
    public const int CCMSE_ERROR_SCALING = 61435;

    /// CCMSE_ERROR_KB -> (0xEFFA)
    public const int CCMSE_ERROR_KB = 61434;

    /// CCMSE_ERROR_MOUSE -> (0xEFF9)
    public const int CCMSE_ERROR_MOUSE = 61433;

    /// CCMSE_ERROR_HEADLESS_DISABLED -> (0xEFF8)
    public const int CCMSE_ERROR_HEADLESS_DISABLED = 61432;

    /// CCMSE_ERROR_POST_MESSAGE -> (0xEFF7)
    public const int CCMSE_ERROR_POST_MESSAGE = 61431;

    /// CCMSE_ERROR_BOTTOM -> (0xE000)
    public const int CCMSE_ERROR_BOTTOM = 57344;

    /// CCM_CLIENT_ERROR_BASE -> (0x3FFF)
    public const int CCM_CLIENT_ERROR_BASE = 16383;

    /// CCM_CLIENT_ERROR_BOTTOM -> (0x0001)
    public const int CCM_CLIENT_ERROR_BOTTOM = 1;
}
public static class TestTimeOut
{
    public static int eventTimeOut = 30; // 30 second

    public static int acrTimeOut = 10;
    public static int EventTimeOut
    {
        set
        {
            EventTimeOut = value;
        }
        get
        {

            return eventTimeOut;
        }
    }
    public static int ACRTimeOut
    {
        set
        {
            acrTimeOut = value;
        }
        get
        {

            return acrTimeOut;
        }
    }
}
