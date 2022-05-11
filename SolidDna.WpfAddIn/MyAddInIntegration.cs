using System.IO;
using AngelSix.SolidDna;

namespace SolidDna.WpfAddIn
{
    /// <summary>
    /// register as a solidworks add-in
    /// </summary>
    public class MyAddInIntegration:AddInIntegration
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
        private TaskpaneIntegration<MyTaskpaneUI> mTaskpane;
        public override void ConnectedToSolidWorks()
        {
            //create a taskpane
            mTaskpane = new TaskpaneIntegration<MyTaskpaneUI>()
            {
                Icon = Path.Combine(Path.GetDirectoryName(typeof(MyAddInIntegration).Assembly.CodeBase).Replace(@"file:\", ""), "life-solid.png"),
                WpfControl = new MyAddInControl()
            };
           mTaskpane.AddToTaskpaneAsync();
        }
        public override void DisconnectedFromSolidWorks()
        {
        }
    }
}
