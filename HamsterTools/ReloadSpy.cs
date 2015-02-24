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

namespace HamsterTools
{
    public partial class ReloadSpy : Form
    {

        ReloadNode selectedNode;

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
                        break;
                    case ReloadNodeType.Byte:
                        break;
                    case ReloadNodeType.Int16:
                        break;
                    case ReloadNodeType.Int32:
                        break;
                    case ReloadNodeType.Int64:
                        break;
                    case ReloadNodeType.Double:
                        break;
                    case ReloadNodeType.String:
                        break;
                    default:
                        break;
                }
            }
        }

        private void valueTextBox_Validating(object sender, CancelEventArgs e)
        {

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
    }
}
