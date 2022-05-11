using System.IO;
using AngelSix.SolidDna;

namespace SolidDna.CustomProperties
{
    /// <summary>
    /// register as a solidworks add-in
    /// </summary>
    public class SolidDnaIntegration:AddInIntegration
    {
        /// <summary>
        /// specific application start-up code
        /// </summary>
        public override void ApplicationStartup()
        {
        }
        public override void PreConnectToSolidWorks()
        {
        }
        public override void PreLoadPlugIns()
        {
        }
    }
    /// <summary>
    /// my first soliddna plugin
    /// </summary>
    public class MySolidDnaPlugin : SolidPlugIn
    {
        public override string AddInTitle =>"My Add-in Title";
        public override string AddInDescription => "My Add-in Description";
        /// <summary>
        /// taskpane ui for our plug-in
        /// </summary>
        private TaskpaneIntegration<TaskpaneUserControlHost> mTaskpane;
        public override void ConnectedToSolidWorks()
        {
            //create a taskpane
            mTaskpane = new TaskpaneIntegration<TaskpaneUserControlHost>()
            {
                Icon = Path.Combine(Path.GetDirectoryName(typeof(SolidDnaIntegration).Assembly.CodeBase).Replace(@"file:\", ""), "life-solid.png"),
                WpfControl = new CustomPropertiesUI()
            };
           mTaskpane.AddToTaskpaneAsync();
        }
        public override void DisconnectedFromSolidWorks()
        {
        }
    }
}
