using System.Runtime.InteropServices;
using System.Windows.Forms;
using AngelSix.SolidDna;

namespace SolidDna.CustomProperties
{
    [ProgId(MyProgId)]
    public partial class TaskpaneUserControlHost : UserControl,ITaskpaneControl
    {
        /// <summary>
        /// our unique progid for solidworks to find and load us
        /// </summary>
        private const string MyProgId = "SolidDna.Taskpane";
        public string ProgId => MyProgId;

        public TaskpaneUserControlHost()
        {
            InitializeComponent();
        }
    }
}
