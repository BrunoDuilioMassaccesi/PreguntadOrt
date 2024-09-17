using System;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadOrt;

static public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=true;";

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> Lista = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Categoria>("SELECT * FROM Categorias").ToList();
        }       
        return Lista;
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> Lista = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Dificultad>("SELECT * FROM Dificultades").ToList();
        }       
        return Lista;
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        List<Pregunta> Lista = null;
        string sql = " ";
        if(dificultad != -1 && categoria != -1)
        {
            sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad and IdCategoria = @pCategoria";
        }
        else if(dificultad == -1 && categoria == -1)
        {
            sql = "SELECT * FROM Preguntas";
        }
        else if(categoria == -1)
        {
            sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad";
        }
        else
        {
            sql = "SELECT * FROM Preguntas WHERE IdCategoria = @pCategoria";
        }

        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Pregunta>(sql, new{pDificultad = dificultad, pCategoria = categoria}).ToList();
        }       
        return Lista;
    }

    public static List<Respuesta> ObtenerRespuestas(int idPregunta)
    {
        List<Respuesta> Lista = null;
        string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Respuesta>(sql, new{pId = idPregunta}).ToList();
        }       
        return Lista;
    }

    public static string CualEsCorrecta(int idPregunta)
    {
        string correcta=null;
         string sql = "SELECT * FROM Respuestas  WHERE Correcta = 1 and IdPregunta = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            correcta = db.Query<string>(sql, new{pId = idPregunta}).FirstOrDefault();
        }       
        return correcta;
    }

    


}