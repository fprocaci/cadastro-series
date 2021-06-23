using System;
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries.classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSerie = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            ListaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}