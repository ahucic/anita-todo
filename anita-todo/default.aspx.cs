using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace anita_todo
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                PopulateList();
            }
        }
        protected void ToDoListBoxes_OnSelectedIndexChange(object sender, EventArgs e)
        {
            for(int i=0; i < ToDoListBoxes.Items.Count; i++)
            {
                if (ToDoListBoxes.Items[i].Selected)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();

                    todo SelectedItem = db.todos.Where(p => 
                    p.todoID == Convert.ToInt32(ToDoListBoxes.Items[i].Value)).FirstOrDefault();

                    db.todos.DeleteOnSubmit(SelectedItem);
                    db.SubmitChanges();
                    PopulateList();
                }
            }
        }
        protected void CreateToDo_OnClick (object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            todo CurrentToDo = new todo
            {
                dt = DateTime.Now,
                name = ToDoName.Text
            };

            db.todos.InsertOnSubmit(CurrentToDo);
            db.SubmitChanges();
            PopulateList();
        }
        private void PopulateList()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            ToDoListBoxes.DataSource = db.todos;
            ToDoListBoxes.DataValueField = "ToDoID";
            ToDoListBoxes.DataTextField = "Name";

            ToDoListBoxes.DataBind();


        }
    }
}