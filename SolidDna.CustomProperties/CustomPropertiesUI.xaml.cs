using System.Windows;
using AngelSix.SolidDna;
using UserControl = System.Windows.Controls.UserControl;

namespace SolidDna.CustomProperties
{
    /// <summary>
    /// MyAddInControl.xaml 的交互逻辑
    /// </summary>
    public partial class CustomPropertiesUI : UserControl
    {
        #region Private Members
        private const string CustomPropertyDescription = "Description";
        private const string CustomPropertyStatus = "Status";
        private const string CustomPropertyRevision = "Revision";
        private const string CustomPropertyPartNumber = "PartNo";
        private const string CustomPropertyManufacturingInformation = "Manufacturing Information";
        private const string CustomPropertyLength = "Length";
        private const string CustomPropertyFinish = "Finish";
        private const string CustomPropertyPurchaseInformation = "Purchase Information";
        private const string CustomPropertySupplierName = "Supplier";
        private const string CustomPropertySupplierCode = "Supplier Number / Code";
        private const string CustomPropertyNote = "Note";

        private const string ManufacturingWeld = "WELD";
        private const string ManufacturingAssembly = "ASSEMBLY";
        private const string ManufacturingPlasma = "PLASMA";
        private const string ManufacturingLaser = "LASER";
        private const string ManufacturingPurchase = "PURCHASE";
        private const string ManufacturingLathe = "LATHE";
        private const string ManufacturingDrill = "DRILL";
        private const string ManufacturingFold = "FOLD";
        private const string ManufacturingRoll = "ROLL";
        private const string ManufacturingSaw = "SAW";
        #endregion

        public CustomPropertiesUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fired when the control is fully loaded
        /// </summary>
        private void CustomPropertiesUI_OnLoaded(object sender, RoutedEventArgs e)
        {
            //by default show the no part open screen
            NoPartContent.Visibility = Visibility.Visible;
            MainContent.Visibility = Visibility.Hidden;
            //listen out for the active model changing
            SolidWorksEnvironment.Application.ActiveModelInformationChanged +=
                Application_ActiveModelInformationChanged;
        }
        /// <summary>
        /// fired when the active solidworks model is changed
        /// </summary>
        /// <param name="obj"></param>
        private void Application_ActiveModelInformationChanged(Model obj)
        {
            ReadDetials();
        }
        /// <summary>
        /// reads all the details from the active solidworks model
        /// </summary>
        private void ReadDetials()
        {
            ThreadHelpers.RunOnUIThread(() =>
            {
                //get the active model
                var model = SolidWorksEnvironment.Application.ActiveModel;
                //if we have no model, or the model is not a part
                //then show the no part screen and return
                if (model == null || !model.IsPart)
                {
                    //show the no part screen
                    NoPartContent.Visibility = Visibility.Visible;
                    MainContent.Visibility = Visibility.Hidden;
                    return;
                }
                //if we got here,we have a part then show the main content
                NoPartContent.Visibility = Visibility.Hidden;
                MainContent.Visibility = Visibility.Visible;
            });
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
