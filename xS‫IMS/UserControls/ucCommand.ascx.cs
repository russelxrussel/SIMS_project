using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucCommand : System.Web.UI.UserControl
{
    
   


    public enum _Commands
    {  
        NEW = 1,
        EDIT = 2,
        UPDATE = 3,
        SAVE = 4,
        CANCEL = 5,
        REMOVE = 6,
        PRINT = 7,
        PRINTSELECT = 8
    }

  //  public event EventHandler ButtonClick;
    
    private int commandType;

    public event EventHandler selectedCommand;

  

    protected void Page_Load(object sender, EventArgs e)
    {
  
    }

    public int COMMANDSELECT
    {
        get { return commandType; }
    }


  

    protected void btnNew_Click(object sender, EventArgs e)
    {

        this.commandType = 1;

        if (this.selectedCommand != null)
            selectedCommand(this, EventArgs.Empty);

        
    }
    protected void btnEDIT_Click(object sender, EventArgs e)
    {
        this.commandType = 2;

        if (this.selectedCommand != null)
            selectedCommand(this, EventArgs.Empty);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompleteList(string prefixText, int count, string contextKey)
    {
        string[] names = { "Russel", "Rose", "Rex", "Vasquze", "Valguna", "Veti", "AdaD", "Aadad" };
        var nameList = from tmp in names where tmp.ToLower().StartsWith(prefixText) select tmp;
        return nameList.ToArray();

    }
}