using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.Bars;

namespace DXPivotGrid_CopyToClipboard {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_CopyToClipboard.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }
        private void itemCopyToClipboard_ItemClick(object sender, ItemClickEventArgs e) {
            pivotGridControl1.CopySelectionToClipboard();
        }
        private void PopupMenu_Opening(object sender, CancelEventArgs e) {
            if (pivotGridControl1.Selection.IsEmpty)
                e.Cancel = true;
        }
    }
}
