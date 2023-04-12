using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CRUDSqlite.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDSqlite.Data
{
    public class SQLiteHelper
    {
       SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath) 
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Student>().Wait();
        
        }

        public Task<int> SaveStudentAysnc(Student studen)
        {
            if (studen.IdStudent !=0) 
            {
                return db.UpdateAsync(studen);
            }
            else
            {
                return db.InsertAsync(studen);
            }
        }

        public Task<int> DeleteStudentAsync(Student studen)
        {
            return db.DeleteAsync(studen);  
        }


        //Mostrar todos los estudiantes
        public Task<List<Student>> GetStudentAysync()
        {
            return db.Table<Student>().ToListAsync();

        }

        //Mostrar todos los estudiantes por id
        public Task<Student> GetStudentByIdAsync(int id)
        {
            return db.Table<Student>().Where(a=> a.IdStudent==id).FirstOrDefaultAsync();
        }



    }
}
