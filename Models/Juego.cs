namespace PreguntadOrt;

static public class Juego
{
    static private string Usuario;
    static private int PuntajeActual;
    static private int CantCorrectas;
    static private int ContadorNroPreguntaActual;
    static private Pregunta PreguntaActual;
    static private List<Pregunta> ListaPreguntas;
    static private List<Respuesta> ListaRespuestas;


    static private void InicializarJuego(string user)
    {
        Usuario = user;
        PuntajeActual = 0;
        CantCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null; 
        ListaRespuestas = null;
    }

    static public List<Categoria> ObtenerCategorias()
    {
        return(BD.ObtenerCategorias());
    }

    static public List<Dificultad> ObtenerDificultades()
    {
        return(BD.ObtenerDificultades());
    }

    static public void CargarPartida(string username, int dificultad, int categoria)
    {
        InicializarJuego(username);
        ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
    }

    static public Pregunta ObtenerProximaPregunta()
    {
        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
        return PreguntaActual;
    }

    static public List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
        return ListaRespuestas;
    }

    public static bool VerificarRespuesta (int IdRespuesta)
    {
        bool Respuesta = false;
        foreach (Respuesta rta in ListaRespuestas)
        {
            if (Respuesta)
            {
                Respuesta = true;

                    if(PreguntaActual.IdDificultad == 1)
                    {
                        PuntajeActual+=150;
                    }
                    else if(PreguntaActual.IdDificultad == 2)
                    {
                        PuntajeActual+=300;
                    }
                    else
                    {
                        PuntajeActual+=500;
                    }
                    CantCorrectas++;

            }
            
        }        
        return Respuesta;
    }  

    public int CantidadPreguntas()
    {
        return ListaPreguntas.count;
    }

    


    
}