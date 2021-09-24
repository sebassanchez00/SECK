using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
  public   class NUsuarios
    {

      public static string Insertar(string cedula, string nombre, string apellidos,string tipolicencia,string empresa,string genero, byte[] imagen)
      {
          DUsuarios Obj = new DUsuarios();

          Obj.Cedula = cedula;
          Obj.Nombre = nombre;
          Obj.Apellidos = apellidos;
          Obj.TipoLicencia = tipolicencia;
          Obj.Empresa = empresa;
          Obj.Genero = genero;
          Obj.Imagen = imagen;


          return Obj.insertar(Obj);
      }

      public static string Editar(string cedula, string nombre, string apellidos, string tipolicencia, string empresa, string genero, byte[] imagen)
      {
          DUsuarios Obj = new DUsuarios();

          Obj.Cedula = cedula;
          Obj.Nombre = nombre;
          Obj.Apellidos = apellidos;
          Obj.TipoLicencia = tipolicencia;
          Obj.Empresa = empresa;
          Obj.Genero = genero;
          Obj.Imagen = imagen;

          return Obj.Editar(Obj);
      }


      public static int  ConsultarUsuario(string textobucar){
           DUsuarios Obj = new DUsuarios();
          Obj.TextoBuscar = textobucar;

            return Obj.BuscarRegistroUsuario(Obj);
         
      }


      public static string[] MostrarDatos(string textobucar)
      {
          DUsuarios Obj = new DUsuarios();
          Obj.TextoBuscar = textobucar;
          return Obj.MostrarUsuario(Obj);
      }

    }
}
