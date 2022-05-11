using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlankAddin
{
    [ProgId(TaskpaneIntegration.SWTASKPANE_PROGID)]
    public partial class TaskpaneHostUI : UserControl
    {
        public TaskpaneHostUI()
        {
            InitializeComponent();
        }
    }
}
