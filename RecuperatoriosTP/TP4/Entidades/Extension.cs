using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace System.Collections.Generic
{
    public static class Extension
    {
        /// <summary>
        /// Método estático para moodificar/actualizar un arma de la base de datos.
        /// </summary>
        /// <returns>Retora booleano (true) si se modificó en la basde de datos o (false) si no.</returns>
        public static bool Modificar(this Armamento arma)
        {
            ArmamentoBD armaBD = new ArmamentoBD();
            return armaBD.ModificarArma(arma);
        }

        /// <summary>
        /// Método estático para eliminar un arma de la base de datos.
        /// </summary>
        /// <returns>Retora booleano (true) si se eliminó de la basde de datos o (false) si no.</returns>
        public static bool Eliminar(this Armamento arma)
        {
            ArmamentoBD armaBD = new ArmamentoBD();
            return armaBD.EliminarArma(arma);
        }
    }
}

