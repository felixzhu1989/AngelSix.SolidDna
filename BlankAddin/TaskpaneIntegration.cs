using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace BlankAddin
{
    /// <summary>
    /// Our solidworks taskpane add-in
    /// </summary>
    public class TaskpaneIntegration:ISwAddin
    {
        /// <summary>
        /// the cookie to the current instance of solidworks we are running inside of当前运行插件的solidworks实例的cookie
        /// </summary>
        private int mSwCookie;
        /// <summary>
        /// the taskpane view for our add-in
        /// </summary>
        private TaskpaneView mTaskpaneView;
        /// <summary>
        /// the ui control that is going to be inside the solidworks taskpane view
        /// </summary>
        private TaskpaneHostUI mTaskpaneHost;
        /// <summary>
        /// the current instance of the solidworks application
        /// </summary>
        private SldWorks mSolidWorksApplication;
        /// <summary>
        /// the unique id to the taskpane used for registration in COM
        /// </summary>
        public const string SWTASKPANE_PROGID = "Angelsix.BlankAddin.Taskpane";
        /// <summary>
        /// call when solidworks has loaded our add-in and wants us to do our connection logic
        /// </summary>
        /// <param name="ThisSW">the current solidworks instance</param>
        /// <param name="Cookie">the current solidworks cookie id</param>
        /// <returns></returns>
        public bool ConnectToSW(object ThisSW, int Cookie)
        {
            //store a reference to the current solidworks instance
            mSolidWorksApplication = (SldWorks)ThisSW;
            //store cookie id
            mSwCookie = Cookie;
            //setup callback info
            var ok = mSolidWorksApplication.SetAddinCallbackInfo2(0,this,mSwCookie);
            LoadUI();
            return ok;
        }
        /// <summary>
        /// load our taskpane and inject our host ui
        /// </summary>
        private void LoadUI()
        {
            //image <40x40pxi，将图片拷贝进来，属性为内容，较新复制
            var imagePath = Path.Combine(Path.GetDirectoryName(typeof(TaskpaneIntegration).Assembly.CodeBase).Replace(@"file:\", ""), "life-solid.png");
            mSolidWorksApplication.CreateTaskpaneView2(imagePath,"My first swAdd-in");
            //find the progid and inject ui, load our ui to the taskpane
            mTaskpaneHost = (TaskpaneHostUI)mTaskpaneView.AddControl(TaskpaneIntegration.SWTASKPANE_PROGID, string.Empty);


        }

        /// <summary>
        /// call when solidworks is about to unload our add-in and wants us to do our disconnection logic
        /// </summary>
        /// <returns></returns>
        public bool DisconnectFromSW()
        {
            UnLoadUI();
            return true;
        }
        /// <summary>
        /// cleanup the taskpane when we disconnect/unload
        /// </summary>
        private void UnLoadUI()
        {
            mTaskpaneHost = null;
            //remove taskpane view
            mTaskpaneView.DeleteView();
            //release com reference and cleanup memory
            Marshal.ReleaseComObject(mTaskpaneView);
            mTaskpaneView = null;
        }

        /// <summary>
        /// the com registration call to add our registry entries to the solidworks add-in registry
        /// </summary>
        /// <param name="t"></param>
        [ComRegisterFunction()]
        private static void ComRegister(Type t)
        {
            var keyPath = string.Format(@"SOFTWARE\SolidWorks\AddIns\{0:B}", t.GUID);
            //create our register folder for the add-in
            using (var rk = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(keyPath))
            {
                //load add-in when solidworks opens
                rk.SetValue(null,1);
                //set solidworks add-in title and description
                rk.SetValue("Title","My SwAddin");
                rk.SetValue("Description","This is ma first addin.");
            }
        }

        /// <summary>
        /// the com unregister call to the remove our custom entries we added in the com register function
        /// </summary>
        /// <param name="t"></param>
        [ComRegisterFunction()]
        private static void ComUnRegister(Type t)
        {
            var keyPath = string.Format(@"SOFTWARE\SolidWorks\AddIns\{0:B}", t.GUID);
            //remove our register entry 
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKey(keyPath);
        }
    }
}
