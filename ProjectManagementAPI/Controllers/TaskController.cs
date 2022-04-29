using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectManagementAPI.Models;
using System.Data;

namespace ProjectManagementAPI.Controllers
{
    public class ResponseWithId
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public int Id { get; set; }
        public List<dynamic> Data { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public TaskController(IConfiguration config, IWebHostEnvironment env)
        {
            _configuration = config;
            _env = env;
        }

        [HttpGet]
        public ResponseWithId Get()
        {
            ResponseWithId resp = new ResponseWithId();
            string sqlDataSource = _configuration.GetConnectionString("ProjectMgt");
            SqlDataReader myReader;
            string query = @"select * from task";
            string maxId = @"select max(id) as last_id from task";
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                }
                using (SqlCommand cmd = new SqlCommand(maxId, myCon))
                {
                    myReader = cmd.ExecuteReader();
                    table2.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> dataList = new List<dynamic>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //int i = 0;
                Models.Task modeldata = new Models.Task();
                modeldata.Id = Convert.ToInt32(table.Rows[i]["id"]);
                modeldata.TaskName = table.Rows[i]["task_name"].ToString();
                modeldata.ProjectId = Convert.ToInt32(table.Rows[i]["project_id"]);
                modeldata.Priority = Convert.ToInt32(table.Rows[i]["priority"]);
                modeldata.Description = table.Rows[i]["description"].ToString();
                modeldata.PlannedStartDate = (DateTime?)table.Rows[i]["planned_start_date"];
                modeldata.PlannedEndDate = (DateTime?)table.Rows[i]["planned_end_date"];
                modeldata.PlannedBudget = Convert.ToDecimal(table.Rows[i]["planned_budget"]);
                modeldata.ActualStartTime = (DateTime?)table.Rows[i]["actual_start_time"];
                modeldata.ActualEndTime = (DateTime?)table.Rows[i]["actual_end_time"];
                modeldata.ActualBudget = Convert.ToDecimal(table.Rows[i]["actual_budget"]);
                dataList.Add(modeldata);
            }

            
            resp.Id = Convert.ToInt32(table2.Rows[0]["last_id"]);

            resp.Data = dataList;
            resp.Status = true;
            resp.Message = "Task Data received successfully";
            return resp;
        }

        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            ResponseModel resp = new ResponseModel();
            string sqlDataSource = _configuration.GetConnectionString("ProjectMgt");
            SqlDataReader myReader;
            string query = @"select * from task where id=@id";
            DataTable table = new DataTable();

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            List<dynamic> dataList = new List<dynamic>();

            int i = 0;
            Models.Task modeldata = new Models.Task();
            modeldata.Id = Convert.ToInt32(table.Rows[i]["id"]);
            modeldata.TaskName = table.Rows[i]["task_name"].ToString();
            modeldata.ProjectId = Convert.ToInt32(table.Rows[i]["project_id"]);
            modeldata.Priority = Convert.ToInt32(table.Rows[i]["priority"]);
            modeldata.Description = table.Rows[i]["description"].ToString();
            modeldata.PlannedStartDate = (DateTime?)table.Rows[i]["planned_start_date"];
            modeldata.PlannedEndDate = (DateTime?)table.Rows[i]["planned_end_date"];
            modeldata.PlannedBudget = Convert.ToDecimal(table.Rows[i]["planned_budget"]);
            modeldata.ActualStartTime = (DateTime?)table.Rows[i]["actual_start_time"];
            modeldata.ActualEndTime = (DateTime?)table.Rows[i]["actual_end_time"];
            modeldata.ActualBudget = Convert.ToDecimal(table.Rows[i]["actual_budget"]);
            dataList.Add(modeldata);

            resp.Data = dataList;
            resp.Status = true;
            resp.Message = "Task Data received successfully";
            return resp;
        }

        [HttpPost]
        public StatusResponseModel Post(Models.Task modeldata)
        {
            StatusResponseModel resp = new StatusResponseModel();
            string sqlDataSource = _configuration.GetConnectionString("ProjectMgt");
            SqlDataReader myReader;
            string query = @"insert into task (column)" +
                "values (@column)";

            DataTable table = new DataTable();

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@task_name", modeldata.TaskName);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            resp.Status = true;
            resp.Message = "Task Data inserted successfully";
            return resp;
        }

        [HttpPut]
        public StatusResponseModel Put(Models.Task modeldata)
        {
            StatusResponseModel resp = new StatusResponseModel();
            string sqlDataSource = _configuration.GetConnectionString("ProjectMgt");
            SqlDataReader myReader;
            string query = @"update task set column=@column" +
                "where id=@id";

            DataTable table = new DataTable();

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@id", modeldata.Id);
                    cmd.Parameters.AddWithValue("@task_name", modeldata.TaskName);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            resp.Status = true;
            resp.Message = "Task Data updated successfully";
            return resp;
        }

        [HttpDelete("{id}")]
        public StatusResponseModel Delete(int id)
        {
            StatusResponseModel resp = new StatusResponseModel();
            string sqlDataSource = _configuration.GetConnectionString("ProjectMgt");
            SqlDataReader myReader;
            string query = @"delete from task where id=@id";

            DataTable table = new DataTable();

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            resp.Status = true;
            resp.Message = "Task Data deleted successfully";
            return resp;
        }
    }
}
