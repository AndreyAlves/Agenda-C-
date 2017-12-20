using System;

namespace AgendaAndrey
{
    internal class Nota
    {

        public int id { get; set; }
        public String tituloNota { get; set; }
        public String txtNota { get; set; }

        public override string ToString()
        {
            return tituloNota;
        }

    }
}