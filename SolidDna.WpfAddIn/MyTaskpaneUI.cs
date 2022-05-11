using System.Runtime.InteropServices;
using System.Windows.Forms;
using AngelSix.SolidDna;

namespace SolidDna.WpfAddIn
{
    [ProgId(MyProgId)]
    public partial class MyTaskpaneUI : UserControl,ITaskpaneControl
    {
        /// <summary>
        /// our unique progid for solidworks to find and load us
        /// </summary>
        private const string MyProgId = "SolidDna.Taskpane";
        public string ProgId => MyProgId;

        public MyTaskpaneUI()
        {
            InitializeComponent();
        }
    }
}
