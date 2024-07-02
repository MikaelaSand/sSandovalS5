using SQLite;
using sSandovalS5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sSandovalS5.Utils
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void Init() 
        { 
            if (conn is not  null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public  PersonRepository (string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre) 
        { 
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El Nombre Es Requerido");

                Persona persona = new() { Nombre = nombre };
                result = conn.Insert(persona);
                StatusMessage = string.Format("Dato Añadido Correstamente", result, nombre);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error Al Insertar", ex.Message); 
            }


        }

        public List<Persona>GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error Al Insertar", ex.Message); 
            }
            return new List<Persona>();
        }

        public void DeletePerson(Persona persona)
        {
            Init();
            conn.Delete(persona);
        }

        public void UpdatePerson(Persona persona)
        {
            Init();
            conn.Delete(persona);
        }

    }

}
