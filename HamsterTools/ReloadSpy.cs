using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HamsterTools.Reload;
using System.IO;

namespace HamsterTools
{
    public partial class ReloadSpy : Form
    {

        ReloadNode openNode = null;
        string fileLocation = "";
        ReloadNode selectedNode;
        Nullable<bool> dialogResult;

        Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();
        private bool saved = false;

        public ReloadSpy()
        {
            InitializeComponent();
            nodeTree.Nodes.Clear(); // get rid of the designer tree
            valueFail.SetIconAlignment(this.valueTextBox, ErrorIconAlignment.MiddleRight);
            valueFail.SetIconPadding(this.valueTextBox, 2);
        }

        class reloadTreeNode : TreeNode
        {
            private ReloadNode _node;
            public ReloadNode Node
            {
                get
                {
                    return _node;
                }
            }

            public reloadTreeNode(ReloadNode n)
            {
                _node = n;
                this.Text = n.Name;

                switch (n.Type)
                {
                    case ReloadNodeType.Null:
                        this.ImageIndex = 0;
                        this.SelectedImageIndex = 0;
                        break;
                    case ReloadNodeType.Byte:
                        this.ImageIndex = 1;
                        this.SelectedImageIndex = 1;
                        break;
                    case ReloadNodeType.Int16:
                        this.ImageIndex = 2;
                        this.SelectedImageIndex = 2;
                        break;
                    case ReloadNodeType.Int32:
                        this.ImageIndex = 3;
                        this.SelectedImageIndex = 3;
                        break;
                    case ReloadNodeType.Int64:
                        this.ImageIndex = 4;
                        this.SelectedImageIndex = 4;
                        break;
                    case ReloadNodeType.Double:
                        this.ImageIndex = 5;
                        this.SelectedImageIndex = 5;
                        break;
                    case ReloadNodeType.String:
                        this.ImageIndex = 6;
                        this.SelectedImageIndex = 6;
                        break;
                    default:
                        break;
                }
            }
        }

        private void valueTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errMsg;
            if (!fitsType(valueTextBox.Text, out errMsg))
            {
                //stop everything!
                e.Cancel = true;
                valueTextBox.Select(0, valueTextBox.Text.Length);

                this.valueFail.SetError(valueTextBox, errMsg);
            }
        }

        private bool fitsType(string value, out string errorMessage)
        {
            errorMessage = "";
            bool okay = false;
            switch (selectedNode.Type)
            {
                case ReloadNodeType.Null:
                    //the data will be tossed in any case
                    return true;
                case ReloadNodeType.Byte:
                    byte byteResult;
                    okay = Byte.TryParse(value, out byteResult);
                    if (!okay)
                    {
                        errorMessage = "Can't convert this value to a byte.\n"
                            + "Bytes range from " + Byte.MinValue + " to " + Byte.MaxValue;
                    }
                    return okay;
                case ReloadNodeType.Int16:
                    short shortResult;
                    okay = Int16.TryParse(value, out shortResult);
                    if (!okay)
                    {
                        errorMessage = "Can't convert this value to a 16-bit integer.\n"
                            + "Int16s range from " + Int16.MinValue + " to " + Int16.MaxValue;
                    }
                    return okay;
                case ReloadNodeType.Int32:
                    int intResult;
                    okay = Int32.TryParse(value, out intResult);
                    if (!okay)
                    {
                        errorMessage = "Can't convert this value to a 32-bit integer.\n"
                            + "Int32s range from " + Int32.MinValue + " to " + Int32.MaxValue;
                    }
                    return okay;
                case ReloadNodeType.Int64:
                    long longResult;
                    okay = Int64.TryParse(value, out longResult);
                    if (!okay)
                    {
                        errorMessage = "Can't convert this value to a 64-bit integer.\n"
                            + "Int64s range from " + Int64.MinValue + " to " + Int64.MaxValue;
                    }
                    return okay;
                case ReloadNodeType.Double:
                    double doubleResult;
                    okay = Double.TryParse(value, out doubleResult);
                    if (!okay)
                    {
                        errorMessage = "Can't convert this value to a double.\n"
                            + "Doubles range from " + Double.MinValue + " to " + Double.MaxValue;
                    }
                    return okay;
                case ReloadNodeType.String:
                    //We don't really care about string data
                    return true;
                default:
                    errorMessage = "Something went wrong!";
                    return false;
            }
        }

        private void valueTextBox_Validated(object sender, EventArgs e)
        {
            //everything worked okay, clear the error
            valueFail.SetError(valueTextBox, "");
        }

        private void nodeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openDlg = new Microsoft.Win32.OpenFileDialog();
            openDlg.DefaultExt = ".reld";
            openDlg.Filter = "RELOAD Files|*.reld";

            dialogResult = openDlg.ShowDialog();
            if (dialogResult == true)
            {
                try
                {
                    openNode = ReloadFileIO.readReloadFile(openDlg.FileName);
                    nodeTree.Nodes.Clear(); //close the previous file;
                    nodeTree.Nodes.Add(populateTree(openNode));
                }
                catch (FileFormatException)
                {
                    MessageBox.Show("RELOADSpy can't open this file because it doesn't appear to be a RELOAD file.",
                        "RELOADSpy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidDataException)
                {
                    MessageBox.Show("This RELOAD file appears to be corrupt.",
                        "RELOADSpy", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Can't find this file. It may have been deleted or moved.", 
                        "RELOADSpy", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private reloadTreeNode populateTree(ReloadNode n)
        {
            reloadTreeNode result = new reloadTreeNode(n);

            foreach (ReloadNode child in n.Children)
            {
                result.Nodes.Add(populateTree(child));
            }

            return result;
        }
    }
}
