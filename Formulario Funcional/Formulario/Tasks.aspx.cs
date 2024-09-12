using Formulario.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formulario
{
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTasks();
            }
        }

        private void LoadTasks()
        {
            using (var context = new MyDbContext())
            {

                gvTasks.DataSource = context.Tasks.ToList();
                gvTasks.DataBind();


            }
        }

        //---------------(ADICIONAR AO BANCO)---------------------------------------------------//
        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                // Verifica se já existe uma tarefa com o mesmo título
                string title = txtTitle.Text.Trim();
                var existingTask = context.Tasks.FirstOrDefault(t => t.Title == title);

                if (existingTask != null)
                {
                    // Exibe uma pop-up de alerta caso o título já exista
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('O título já existe! Escolha um título diferente.');", true);
                }
                else
                {
                    var newTask = new Task
                    {
                        Title = title,
                        Description = txtDescription.Text,
                        IsCompleted = chkIsCompleted.Checked
                    };
                    context.Tasks.Add(newTask);
                    context.SaveChanges();
                    LoadTasks();  // Recarrega a lista de tarefas
                }
            }
        }
        //---------------(EDITANDO DADOS)---------------------------------------------------//
        protected void gvTasks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTasks.EditIndex = e.NewEditIndex;
            LoadTasks();
        }
        protected void gvTasks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancelar a edição e definir o índice de edição para -1
            gvTasks.EditIndex = -1;
            // Recarregar os dados para refletir as mudanças
            LoadTasks();
        }

        //---------------(ATUALIZANDO DADOS)---------------------------------------------------//

        protected void gvTasks_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
    int id = (int)gvTasks.DataKeys[e.RowIndex].Value; // Obtém o ID da tarefa
    GridViewRow row = gvTasks.Rows[e.RowIndex]; // Obtém a linha que está sendo editada
    
    // Encontra os controles na linha editável
    string title = (row.FindControl("txtTitle") as TextBox).Text;
    string description = (row.FindControl("txtDescription") as TextBox).Text;
    bool isCompleted = (row.FindControl("chkIsCompleted") as CheckBox).Checked;

    using (var context = new MyDbContext())
    {
        var task = context.Tasks.Find(id); // Encontra a tarefa pelo ID
        if (task != null)
        {
            task.Title = title; // Atualiza o título
            task.Description = description; // Atualiza a descrição
            task.IsCompleted = isCompleted; // Atualiza o status de conclusão
            context.SaveChanges(); // Salva as mudanças no banco de dados
        }
    }

    // Sai do modo de edição
    gvTasks.EditIndex = -1;
    LoadTasks(); // Recarrega as tarefas
}
//---------------()---------------------------------------------------//
        protected void gvTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvTasks.DataKeys[e.RowIndex].Value;

            using (var context = new MyDbContext())
            {
                var task = context.Tasks.Find(id);
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
            LoadTasks();
        }
    }
}
