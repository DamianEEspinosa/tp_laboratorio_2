﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {

        #region ---------------ATRIBBUTOS--------------
        public Universidad.EClases _claseQueToma;
        public EEstadoCuenta _estadoCuenta;
        private int p1;
        private string p2;
        private string p3;
        private string p4;
        private ENacionalidad eNacionalidad;
        private Universidad.EClases eClases;
        private EEstadoCuenta eEstadoCuenta;
        #endregion

        #region --------------CONSTRUCTORES------------
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region -----------------METODOS---------------
        /// <summary>
        /// Devuelve una cadena con los datos del objeto
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("TOMA CLASES DE " + this._claseQueToma);
            return cadena.ToString();
        }
        #endregion

        #region ----------SOBRECARGA DE METODOS--------
        /// <summary>
        /// Devuelve una cadena con los datos del objeto
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }

        /// <summary>
        /// Devuelve una cadena con los datos del objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region ---------SOBRECARGA DE OPERADORES------
        /// <summary>
        /// un objeto alumno es igual a un EClases cuando no es deudor y el primero toma la misma
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            return (alumno._claseQueToma == clase && alumno._estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return !(alumno == clase);
        }

        #endregion

        #region ----------------ENUMERADOS-------------

        public enum EEstadoCuenta
        {
            Deudor,
            AlDia,
            Becado
        }

        #endregion

    }
}


